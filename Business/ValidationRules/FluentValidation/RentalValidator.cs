using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.ReturnDate).NotEmpty().WithMessage("Return Date can't empty.");
            RuleFor(r => r.CarId).NotEmpty().WithMessage("Car Id can't empty");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Customer Id can't empty");
        }

     
    }
}
