using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger))]
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [PerformanceAspect(5)]
        [CacheRemoveAspect("IUserService.Get")]
        [ValidationAspect(typeof(UserValidator), Priority =1)]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run(CheckIfEmailExists(user.Email));
            if (result != null)
            {
                return result;
            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [PerformanceAspect(5)]
        public IResult CheckIfEmailExists(string email)
        {
            if (_userDal.Get(u => u.Email == email) != null)
            {
                return new ErrorResult(Messages.EmailAlreadyExists);
            }
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
