using FluentValidation;
using PaymentProcessor.Application.Shared.Payments.Dto;
using PaymentProcessor.Domain.Shared.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Shared.Payments.Validations
{
    public class PaymentDtoValidator:AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(x => x.CreditCardNumber).CreditCard();
            RuleFor(x => x.CardHolder).NotEmpty();
            RuleFor(x => x.ExpirationDate).NotNull().GreaterThan(DateTime.Now);
            RuleFor(x => x.SecurityCode).Length(PaymentConsts.SecurityCodeLength);
            RuleFor(x => x.Amount).GreaterThan(decimal.Zero);
        }
    }
}
