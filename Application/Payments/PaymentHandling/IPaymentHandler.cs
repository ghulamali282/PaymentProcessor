using PaymentProcessor.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Payments.PaymentHandling
{
    public interface IPaymentHandler
    {
        IPaymentHandler SetNext(IPaymentHandler handler);
        bool Handle(Payment payment);
    }
}
