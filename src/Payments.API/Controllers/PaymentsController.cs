using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Payments.Models;

namespace Payments.API.Controllers
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        // GET api/payments
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return new List<Payment>() 
            { 
                new Payment 
                {
                    Id = "id",
                    Version = 0,
                    OrganisationId = "orgId"
                },
                new Payment 
                {
                    Id = "id2",
                    Version = 0,
                    OrganisationId = "orgId2"
                }
            };
        }

        // GET api/payments/5
        [HttpGet("{id}")]
        public Payment Get(int id)
        {
            return new Payment 
            {
                Id = "id",
                Version = 0,
                OrganisationId = "orgId"
            };
        }

        // POST api/payments
        [HttpPost]
        public void Post([FromBody]Payment value)
        {
        }

        // PUT api/payments/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Payment value)
        {
        }

        // DELETE api/payments/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
