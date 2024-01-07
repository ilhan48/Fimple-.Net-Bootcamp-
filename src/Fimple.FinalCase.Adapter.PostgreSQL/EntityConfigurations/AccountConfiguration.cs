using Fimple.FinalCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserId).HasColumnName("UserId");
        builder.Property(a => a.Balance).HasColumnName("Balance");
        builder.Property(a => a.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(a => a.UpdatedAt).HasColumnName("UpdatedAt");
    }
}