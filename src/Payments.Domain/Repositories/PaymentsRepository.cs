using Payments.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Payments.Repositories
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
            if (_paymentsContext.Payments.Count() == 0)
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

        public void Add(Payment payment)
        {
            _paymentsContext.Payments.Add(payment);
            _paymentsContext.SaveChanges();
        }

        public void Delete(Payment payment)
        {
            _paymentsContext.Payments.Remove(payment);
            _paymentsContext.SaveChanges();
        }

        public Payment Get(string id)
        {
            return _paymentsContext.Payments.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Payment> GetAll()
        {
            return _paymentsContext.Payments.ToList();
        }

        public void Update(Payment payment)
        {
            _paymentsContext.Payments.Update(payment);
            _paymentsContext.SaveChanges();
        }
    }
}