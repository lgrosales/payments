using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Payments.Domain.Models;

namespace Payments.Domain.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly PaymentsContext _paymentsContext;
        private readonly ILogger _logger;

        public PaymentsRepository(PaymentsContext paymentsContext, ILogger<PaymentsRepository> logger)
        {
            _paymentsContext = paymentsContext;
            _logger = logger;

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
            try
            {
                _paymentsContext.Payments.Add(payment);
                return _paymentsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to create payment", payment);
                throw;
            }
        }

        public Task Delete(Payment payment)
        {
            try
            {
                _paymentsContext.Payments.Remove(payment);
                return _paymentsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to delete payment", payment);
                throw;
            }
        }

        public Task<Payment> Get(string id)
        {
            try
            {
                return _paymentsContext.Payments.FirstOrDefaultAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to get payment", id);
                throw;
            }
        }

        public Task<List<Payment>> GetAll()
        {
            try
            {
                return _paymentsContext.Payments.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to get payments");
                throw;
            }
        }

        public Task Update(Payment payment)
        {
            try
            {
                var entity = Get(payment.Id).Result;
                _paymentsContext.Entry(entity).CurrentValues.SetValues(payment);

                return _paymentsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to update payment", payment);
                throw;
            }
        }
    }
}