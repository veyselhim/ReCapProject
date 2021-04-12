using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.City).NotNull();
            RuleFor(c => c.Country).NotNull();
            RuleFor(c => c.City).NotNull();
            RuleFor(c => c.Subject).NotNull();

        }
    }
}
