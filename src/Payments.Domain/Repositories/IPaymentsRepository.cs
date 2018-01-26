using System.Collections.Generic;
using Payments.Domain.Models;

namespace Payments.Domain.Repositories
{
    public interface IPaymentsRepository
    {
        Payment Get(string id);
        IEnumerable<Payment> GetAll();
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
    }
}