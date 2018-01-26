using System;
using System.Collections.Generic;
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
                return _paymentsContext.Payments
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.BeneficiaryParty)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.ChargesInformation)
                        .ThenInclude(inf => inf.SenderCharges)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.DebtorParty)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.Fx)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.SponsorParty)
                    .FirstOrDefaultAsync(t => t.Id == id);
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
                return _paymentsContext.Payments
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.BeneficiaryParty)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.ChargesInformation)
                        .ThenInclude(inf => inf.SenderCharges)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.DebtorParty)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.Fx)
                    .Include(p => p.Attributes)
                        .ThenInclude(att => att.SponsorParty)
                    .ToListAsync();
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