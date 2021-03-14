using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentProcessor.Domain.Payments;
using PaymentProcessor.Domain.Shared.Common;
using PaymentProcessor.Domain.Shared.Payments;

namespace PaymentProcessor.Infrastructer.EntityConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments", PaymentProcessorConsts.DefaultDbSchema)
                .HasKey(b => b.PaymentId);

            builder.Property(b => b.CreditCardNumber)
                .IsRequired();

            builder.Property(b => b.CardHolder)
                .IsRequired();

            builder.Property(b => b.ExpirationDate)
                .IsRequired();

            builder.Property(b => b.SecurityCode)
                .HasMaxLength(PaymentConsts.SecurityCodeLength)
                .IsFixedLength();

            builder.Property(b => b.Amount)
                .IsRequired()
                .HasPrecision(PaymentConsts.AmountPrecision, PaymentConsts.AmountScale);
        }
    }
}
