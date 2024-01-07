using Fimple.FinalCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class AutomaticPaymentConfiguration : IEntityTypeConfiguration<AutomaticPayment>
{
    public void Configure(EntityTypeBuilder<AutomaticPayment> builder)
    {
        builder.ToTable("AutomaticPayments").HasKey(ap => ap.Id);

        builder.Property(ap => ap.Id).HasColumnName("Id").IsRequired();
        builder.Property(ap => ap.UserId).HasColumnName("UserId");
        builder.Property(ap => ap.Amount).HasColumnName("Amount");
        builder.Property(ap => ap.PaymentDate).HasColumnName("PaymentDate");
        builder.Property(ap => ap.Status).HasColumnName("Status");
        builder.Property(ap => ap.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(ap => ap.UpdatedAt).HasColumnName("UpdatedAt");
    }
}