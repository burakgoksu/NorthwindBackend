using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger))]
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [PerformanceAspect(5)]
        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }

            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [PerformanceAspect(5)]
        private IResult CheckIfCategoryNameExists(string categoryName)
        {
            if (_categoryDal.Get(c => c.CategoryName == categoryName) != null)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }
            return new SuccessResult();
        }

        [PerformanceAspect(5)]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        [PerformanceAspect(5)]
        [SecuredOperation("Category.Update,Admin")]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.CategoryName));
            if (result != null)
            {
                return result;
            }

            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
