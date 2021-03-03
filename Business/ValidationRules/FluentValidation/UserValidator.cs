using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim giriniz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyadı giriniz");


        }

       
        //private bool IsPasswordValid(string arg)
        //{
        //    Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
        //    return regex.IsMatch(arg);
        //}
    }
}
