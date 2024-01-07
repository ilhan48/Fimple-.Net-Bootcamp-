using Fimple.FinalCase.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
{
    public void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        builder.ToTable("CreditApplications").HasKey(ca => ca.Id);

        builder.Property(ca => ca.Id).HasColumnName("Id").IsRequired();
        builder.Property(ca => ca.ApplicantId).HasColumnName("ApplicantId");
        builder.Property(ca => ca.RequestedAmount).HasColumnName("RequestedAmount");
        builder.Property(ca => ca.Status).HasColumnName("Status");
        builder.Property(ca => ca.CreatedAt).HasColumnName("CreatedAte").IsRequired();
        builder.Property(ca => ca.UpdatedAt).HasColumnName("UpdatedAt");
    }
}