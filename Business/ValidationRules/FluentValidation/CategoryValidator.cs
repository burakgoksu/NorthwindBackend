using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty();
            RuleFor(c => c.CategoryName).Length(4, 25);
            RuleFor(c => c.CategoryName).Must(StartWithB);
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
