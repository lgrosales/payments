using Microsoft.EntityFrameworkCore;
using Payments.Domain.Models;

namespace Payments.Domain
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentAttributes> PaymentAttributes { get; set; }
        public DbSet<Party> Party { get; set; }
        public DbSet<Fx> Fx { get; set; }
        public DbSet<ChargesInformation> ChargesInformation { get; set; }
        public DbSet<Charge> Charge { get; set; }
    }
}