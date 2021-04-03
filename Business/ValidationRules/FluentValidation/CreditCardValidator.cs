using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator:AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(cc => cc.CVV).MinimumLength(3);
            RuleFor(cc => cc.CVV).MaximumLength(3);
            RuleFor(cc => cc.ExpirationMonth).MinimumLength(2);
            RuleFor(cc => cc.ExpirationMonth).MaximumLength(2);
            RuleFor(cc => cc.ExpirationYear).MinimumLength(4);
            RuleFor(cc => cc.ExpirationYear).MaximumLength(4);
            RuleFor(cc => cc.Number).MinimumLength(16);
            RuleFor(cc => cc.Number).MaximumLength(16);
            RuleFor(cc => cc.FullName).NotEmpty();
        }
    }
}
