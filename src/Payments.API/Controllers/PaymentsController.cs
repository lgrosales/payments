using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payments.Domain.Models;
using Payments.Domain.Repositories;

namespace Payments.API.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentsRepository _paymentsRepository;

        public PaymentsController(IPaymentsRepository paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }
        
        // GET api/payments
        [HttpGet]
        public async Task<IEnumerable<Payment>> Get()
        {
            return await _paymentsRepository.GetAll();
        }

        // GET api/payments/5
        [HttpGet("{id}", Name = "GetPaymentRoute")]
        public async Task<IActionResult> GetById(string id)
        {
            var payment = await _paymentsRepository.Get(id);
            if (payment == null)
            {
                return NotFound();
            }
            return new ObjectResult(payment);
        }

        // POST api/payments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            await _paymentsRepository.Add(payment);

            return CreatedAtRoute("GetPaymentRoute", new { id = payment.Id }, payment);
        }

        // PUT api/payments/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Update(string id, [FromBody]Payment payment)
        {
            if (payment == null || payment.Id != id)
            {
                return BadRequest();
            }

            if (await _paymentsRepository.Get(id) == null)
            {
                return NotFound();
            }

            await _paymentsRepository.Update(payment);
            
            return new NoContentResult();
        }

        // DELETE api/payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var payment = await _paymentsRepository.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            await _paymentsRepository.Delete(payment);

            return new NoContentResult();
        }
    }
}
