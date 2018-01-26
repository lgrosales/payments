using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.Domain.Models;

namespace Payments.Domain.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentsContext _paymentsContext;

        public PaymentsRepository(PaymentsContext paymentsContext)
        {
            _paymentsContext = paymentsContext;

            InitialiseDbData();
        }

        private void InitialiseDbData()
        {
            if (!_paymentsContext.Payments.Any())
            {
                var payments = new List<Payment>() 
                { 
                    new Payment 
                    {
                        Id = "id1",
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

                _paymentsContext.Payments.AddRange(payments);
                _paymentsContext.SaveChanges();
            }
        }

        public Task Add(Payment payment)
        {
           _paymentsContext.Payments.Add(payment);
           return  _paymentsContext.SaveChangesAsync();
        }

        public Task Delete(Payment payment)
        {
            _paymentsContext.Payments.Remove(payment);
            return _paymentsContext.SaveChangesAsync();
        }

        public Task<Payment> Get(string id)
        {
            return _paymentsContext.Payments.FirstOrDefaultAsync(t => t.Id == id);
        }

        public Task<List<Payment>> GetAll()
        {
            return _paymentsContext.Payments.ToListAsync();
        }

        public Task Update(Payment payment)
        {
            _paymentsContext.Payments.Update(payment);
            return _paymentsContext.SaveChangesAsync();
        }
    }
}