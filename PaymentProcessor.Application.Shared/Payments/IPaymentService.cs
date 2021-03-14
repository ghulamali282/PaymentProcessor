using PaymentProcessor.Application.Shared.Payments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Shared.Payments
{
    public interface IPaymentService
    {
        Task ProcessPayment(PaymentDto input);
    }
}
