using Microsoft.EntityFrameworkCore;

namespace Payments.Models
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext(DbContextOptions<PaymentsContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
    }
}