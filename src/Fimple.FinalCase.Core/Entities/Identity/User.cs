using Fimple.FinalCase.Core.Entities.Common;

namespace Fimple.FinalCase.Core.Entities.Identity;

public class User : BaseAuditableEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
    
    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<AutomaticPayment> AutomaticPayments { get; set; }
    public virtual ICollection<CreditApplication> CreditApplications { get; set; }

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
    }

    public User(
        string firstName,
        string lastName,
        string email,
        byte[] passwordSalt,
        byte[] passwordHash,
        bool status
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
}