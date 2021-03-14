using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Shared.Payments
{
    public enum EPaymentState
    {
        Pending,
        Processed,
        Failed
    }
}
