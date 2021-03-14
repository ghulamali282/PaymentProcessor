using AutoMapper;
using PaymentProcessor.Application.Shared.Payments.Dto;
using PaymentProcessor.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.AutoMapper
{
    public class PaymentProcessorMappingProfile:Profile
    {
        public PaymentProcessorMappingProfile()
        {
            CreateMap<PaymentDto, Payment>();
        }
    }
}
