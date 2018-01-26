using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Domain.Models;

namespace Payments.Domain.Repositories
{
    public interface IPaymentsRepository
    {
        Task<Payment> Get(string id);
        Task<List<Payment>> GetAll();
        Task Add(Payment payment);
        Task Update(Payment payment);
        Task Delete(Payment payment);
    }
}