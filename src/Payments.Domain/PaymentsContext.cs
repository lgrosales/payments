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
    }
}