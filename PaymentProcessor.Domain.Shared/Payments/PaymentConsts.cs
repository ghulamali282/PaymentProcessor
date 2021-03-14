using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Domain.Shared.Payments
{
    public static class PaymentConsts
    {
        public const short SecurityCodeLength = 3;
        public const short AmountPrecision = 18;
        public const short AmountScale = 4;
    }
}
