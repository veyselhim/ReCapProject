using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("E-Mail alanı boş geçilemez!");
                //.Must(IsEmailValid).WithMessage("E-Mail geçersiz");

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim giriniz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyadı giriniz");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Parola alanı boş geçilemez!")
                .Must(IsPasswordValid).WithMessage("Parolanız en az 6 karakter, en az bir harf ve bir sayı içermelidir!");




        }

        //private bool IsEmailValid(string arg)
        //{
        //    Regex regex = new Regex(@"[^@]");
        //    return regex.IsMatch(arg);
        //}

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            return regex.IsMatch(arg);
        }
    }
}
