using Fimple.FinalCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.ToTable("Transfers").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.SenderAccountId).HasColumnName("SenderAccountId");
        builder.Property(t => t.ReceiverAccountId).HasColumnName("ReceiverAccountId");
        builder.Property(t => t.Amount).HasColumnName("Amount");
        builder.Property(t => t.Status).HasColumnName("Status");
        builder.Property(t => t.Max).HasColumnName("Max");
        builder.Property(t => t.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
    }
}