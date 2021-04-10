using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CardValidator:AbstractValidator<Card>
    {
        public CardValidator()
        {
            RuleFor(c => c.CardNumber).Length(16,17).WithMessage("Kredi kartı numarası yanlış");
            RuleFor(c => c.Cvv).NotEmpty();
        }
    }
}
