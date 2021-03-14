using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentProcessor.Domain.Payments;
using PaymentProcessor.Domain.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessor.Infrastructer.EntityConfiguration
{
    public class PaymentStateConfiguration : IEntityTypeConfiguration<PaymentState>
    {
        public void Configure(EntityTypeBuilder<PaymentState> builder)
        {
            builder.ToTable("PaymentsState", PaymentProcessorConsts.DefaultDbSchema);
            builder.HasKey(b => b.PaymentId);
            builder.HasOne(b => b.Payment).WithOne();
            builder.Property(b => b.State).IsRequired();
        }
    }
}
