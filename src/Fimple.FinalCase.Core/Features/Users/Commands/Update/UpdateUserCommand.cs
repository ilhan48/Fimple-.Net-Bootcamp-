using Fimple.FinalCase.Core.Features.Users.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.Users.Constants.UsersOperationClaims;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Update;

public partial class UpdateUserCommand : IRequest<UpdatedUserResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UpdateUserCommand()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public UpdateUserCommand(int id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public string[] Roles => new[] { Admin, Write, UsersOperationClaims.Update };
}
