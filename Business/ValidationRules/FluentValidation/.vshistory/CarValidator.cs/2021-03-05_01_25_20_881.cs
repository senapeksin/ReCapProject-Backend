using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Car>
    {
        public ProductValidator()
        {
            RuleFor(c=>c.DailyPrice).GreaterThan(0);
            RuleFor(c=>c.Description).MinimumLength(2);
        }
    }
}
