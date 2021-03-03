using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty().MinimumLength(2);  //Boş geçilemez , en az 2 karakter olmalıu
            RuleFor(c => c.UnitPrice).NotEmpty();
            RuleFor(c => c.UnitPrice).GreaterThan(0);  //Unitprice 0 dan büyük olmak zorunda
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);  //BrandId 1 ise UnitPrice 10a eşit veya 10dan büyük olmalı
        }
    }
}
