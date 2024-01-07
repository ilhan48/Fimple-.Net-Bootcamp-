using Fimple.FinalCase.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class PaymentPlanConfiguration : IEntityTypeConfiguration<PaymentPlan>
{
    public void Configure(EntityTypeBuilder<PaymentPlan> builder)
    {
        builder.ToTable("PaymentPlans").HasKey(pp => pp.Id);

        builder.Property(pp => pp.Id).HasColumnName("Id").IsRequired();
        builder.Property(pp => pp.CreditApplicationId).HasColumnName("CreditApplicationId");
        builder.Property(pp => pp.InstallmentAmount).HasColumnName("InstallmentAmount");
        builder.Property(pp => pp.NumberOfInstallment).HasColumnName("NumberOfInstallment");
        builder.Property(pp => pp.RemainingInstallment).HasColumnName("RemainingInstallment");
        builder.Property(pp => pp.DueDate).HasColumnName("DueDate");
        builder.Property(pp => pp.Status).HasColumnName("Status");
        builder.Property(pp => pp.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(pp => pp.UpdatedAt).HasColumnName("UpdatedAt");
    }
}