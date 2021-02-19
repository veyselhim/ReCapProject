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
            RuleFor(c => c.CarName).NotEmpty();  //Boş geçilemez
            RuleFor(C => C.CarName).MinimumLength(2); //Carname minumum 2 karakter olmalıdır.
            RuleFor(c => c.UnitPrice).NotEmpty();
            RuleFor(c => c.UnitPrice).GreaterThan(0);  //Unitprice 0 dan büyük olmak zorunda
            RuleFor(c => c.UnitPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);  //BrandId 1 ise UnitPrice 10a eşit veya 10dan büyük olmalı
        }
    }
}
