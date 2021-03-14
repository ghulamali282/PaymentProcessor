using Microsoft.EntityFrameworkCore;
using PaymentProcessor.Domain.Payments;
using System.Reflection;

namespace PaymentProcessor.Infrastructer
{
    public class PaymentProcessorDbContext:DbContext
    {
        public PaymentProcessorDbContext(DbContextOptions<PaymentProcessorDbContext> options)
            :base(options) {  }


        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
