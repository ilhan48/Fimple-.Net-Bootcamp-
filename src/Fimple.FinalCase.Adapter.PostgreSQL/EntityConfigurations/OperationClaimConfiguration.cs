using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.OperationClaims.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fimple.FinalCase.Adapter.PostgreSQL.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(oc => oc.UpdatedAt).HasColumnName("UpdatedAt");

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Accounts
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.Delete" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.GetBalanceInformation" });

        seeds.Add(new OperationClaim { Id = ++id, Name = "Accounts.UpdateBalance" });

        
        #endregion
        
        
        #region Processes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Processes.Delete" });
        
        #endregion
        
        
        #region Transfers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Transfers.Delete" });
        
        #endregion
        
        
        #region PaymentPlans
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "PaymentPlans.Delete" });
        
        #endregion
        
        
        #region CreditApplications
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CreditApplications.Delete" });
        
        #endregion
        
        
        #region SupportTickets
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SupportTickets.Delete" });
        
        #endregion
        
        
        #region AutomaticPayments
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "AutomaticPayments.Delete" });
        
        #endregion
        
        return seeds;
    }
}
