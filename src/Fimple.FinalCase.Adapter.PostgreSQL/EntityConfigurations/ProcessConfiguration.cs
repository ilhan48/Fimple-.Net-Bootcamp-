using Fimple.FinalCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class ProcessConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.ToTable("Processes").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.AccountId).HasColumnName("AccountId");
        builder.Property(p => p.Type).HasColumnName("Type");
        builder.Property(p => p.Amount).HasColumnName("Amount");
        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");
    }
}