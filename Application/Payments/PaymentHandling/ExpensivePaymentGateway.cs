using PaymentProcessor.Application.Shared.Payments;
using PaymentProcessor.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Payments.PaymentHandling
{
    public class ExpensivePaymentGateway : PaymentHandler, IPaymentHandler
    {
        protected override bool CanHandleRequest(Payment payment)
        {
            if (payment.Amount > 20 && payment.Amount<=500)
            {
                return true;
            }

            return false;
        }

        protected override bool ProcessPayment(Payment payment)
        {
            return true;
        }
    }
}
