using PaymentProcessor.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Payments.PaymentHandling
{
    public abstract class PaymentHandler : IPaymentHandler
    {
        private IPaymentHandler _nextHanlder;
        public IPaymentHandler SetNext(IPaymentHandler handler)
        {
            _nextHanlder = handler;
            return handler;
        }

        public bool Handle(Payment payment)
        {
            if (CanHandleRequest(payment))
            {
               return ProcessPayment(payment);
            }
            else
            {
               return  _nextHanlder.Handle(payment);
            }

        }

        abstract protected bool CanHandleRequest(Payment payment);

        abstract protected bool ProcessPayment(Payment payment);
    }
}
