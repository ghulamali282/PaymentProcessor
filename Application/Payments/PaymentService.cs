using AutoMapper;
using PaymentProcessor.Application.Payments.PaymentHandling;
using PaymentProcessor.Application.Shared.Payments;
using PaymentProcessor.Application.Shared.Payments.Dto;
using PaymentProcessor.Domain.Payments;
using PaymentProcessor.Domain.Repository;
using PaymentProcessor.Domain.Shared.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Application.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<PaymentState> _paymentStateRepository;
        private readonly IMapper _mapper;
        public PaymentService(IRepository<Payment> paymentRepository,
                              IRepository<PaymentState> paymentStateRepository,
                              IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paymentStateRepository = paymentStateRepository;
            _mapper = mapper;
        }

        public async Task ProcessPayment(PaymentDto input)
        {
            var payment = _mapper.Map<PaymentDto, Payment>(input);

            var cheapPaymentGateway = new CheapPaymentGateway();
            var expensivePaymentGateway = new ExpensivePaymentGateway();

            cheapPaymentGateway.SetNext(expensivePaymentGateway);


            await _paymentRepository.InsertAsync(payment);
            await _paymentRepository.SaveAsync();

            var response =(bool?)cheapPaymentGateway.Handle(payment);

            var paymentState = new PaymentState
            {
                PaymentId = payment.PaymentId,
                State = response switch
                {
                    true => EPaymentState.Processed,
                    false => EPaymentState.Pending,
                    null => EPaymentState.Failed
                }
            };

            await _paymentStateRepository.InsertAsync(paymentState);
            await _paymentRepository.SaveAsync();
        }
    }
}
