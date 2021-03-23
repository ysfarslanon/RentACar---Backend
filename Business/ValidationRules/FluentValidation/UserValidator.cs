using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty();
            RuleFor(user => user.LastName).NotEmpty();
            RuleFor(user => user.Password).NotEmpty();
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.FirstName).MinimumLength(3);
            RuleFor(user => user.LastName).MinimumLength(2);
            RuleFor(user => user.Password).Must(CheckPassword);
        }

        private bool CheckPassword(string arg)
        {
            const int minLenght = 5;
            const int maxLenght = 18;
            if (arg==null)
            {
                throw new ArgumentException();
            }
            bool checkLenght = arg.Length >= minLenght && arg.Length <= maxLenght;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasNumber = false;
            if (checkLenght)
            {
                foreach (char c in arg)
                {
                    if (char.IsUpper(c))
                        hasUpperCase = true;
                    else if (char.IsLower(c))
                        hasLowerCase = true;
                    else if (char.IsDigit(c))
                        hasNumber = true;
                }
            }
            bool isValid = checkLenght && hasUpperCase && hasLowerCase && hasNumber;
            return isValid;
        }
    }
}
