using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.Application.Shared.Payments;
using PaymentProcessor.Application.Shared.Payments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentProcessor.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
      
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto input)
        {           
            await _paymentService.ProcessPayment(input);
            return Ok("Processed");
        }

    }
}
