using Payments.Models;

namespace Payments.Repositories
{
    public class PaymentsRepository
    {
        private readonly PaymentsContext paymentsContext;

        public PaymentsRepository(PaymentsContext paymentsContext)
        {
            this.paymentsContext = paymentsContext;
        }
    }
}