using Fimple.FinalCase.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
{
    public void Configure(EntityTypeBuilder<SupportTicket> builder)
    {
        builder.ToTable("SupportTickets").HasKey(st => st.Id);

        builder.Property(st => st.Id).HasColumnName("Id").IsRequired();
        builder.Property(st => st.AskingId).HasColumnName("AskingId");
        builder.Property(st => st.AnsweringId).HasColumnName("AnsweringId");
        builder.Property(st => st.Issue).HasColumnName("Issue");
        builder.Property(st => st.Answer).HasColumnName("Answer");
        builder.Property(st => st.Status).HasColumnName("Status");
        builder.Property(st => st.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(st => st.UpdatedAt).HasColumnName("UpdatedAt");
    }
}