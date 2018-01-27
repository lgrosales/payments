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

        public async Task Update(Payment payment)
        {
            try
            {
                var paymentEntity = Get(payment.Id).Result;
                _paymentsContext
                    .Entry(paymentEntity)
                    .CurrentValues
                    .SetValues(payment);

                if (paymentEntity.Attributes != null)
                { 
                    var paymentAttributesEntity = await _paymentsContext.PaymentAttributes
                        .FirstOrDefaultAsync(att => att.Id == paymentEntity.Attributes.Id);
                    payment.Attributes.Id = paymentAttributesEntity.Id;
                    _paymentsContext
                        .Entry(paymentAttributesEntity)
                        .CurrentValues
                        .SetValues(payment.Attributes);
                
                    var beneficiaryPartyEntity = await _paymentsContext.Party
                        .FirstOrDefaultAsync(p => p.Id == paymentEntity.Attributes.BeneficiaryParty.Id);
                    payment.Attributes.BeneficiaryParty.Id = beneficiaryPartyEntity.Id;
                    _paymentsContext
                        .Entry(beneficiaryPartyEntity)
                        .CurrentValues
                        .SetValues(payment.Attributes.BeneficiaryParty);

                    // Update all the other value objects
                }

                await _paymentsContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to update payment", payment);
                throw;
            }
        }
    }
}