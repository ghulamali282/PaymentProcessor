using PaymentProcessor.Domain.Shared.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Payments
{
    public class PaymentState
    {
        public int PaymentId { get; set; }
        public EPaymentState State { get; set; }
        public Payment Payment { get; set; }
    }
}
