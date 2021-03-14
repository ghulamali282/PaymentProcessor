using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.Application.Shared.Payments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentProcessor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
      
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto input)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }



            return Ok(string.Empty);
        }

    }
}
