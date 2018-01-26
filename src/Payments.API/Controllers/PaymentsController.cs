using System.Collections.Generic;
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
        public IEnumerable<Payment> Get()
        {
            return _paymentsRepository.GetAll();
        }

        // GET api/payments/5
        [HttpGet("{id}", Name = "GetPaymentRoute")]
        public IActionResult Get(string id)
        {
            var payment = _paymentsRepository.Get(id);
            if (payment == null)
            {
                return NotFound();
            }
            return new ObjectResult(payment);
        }

        // POST api/payments
        [HttpPost]
        public IActionResult Create([FromBody]Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            _paymentsRepository.Add(payment);

            return CreatedAtRoute("GetPaymentRoute", new { id = payment.Id }, payment);
        }

        // PUT api/payments/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Payment value)
        {
        }

        // DELETE api/payments/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
