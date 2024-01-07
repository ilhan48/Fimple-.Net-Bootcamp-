using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.UpdateFromAuth;

public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string? NewPassword { get; set; }

    public UpdateUserFromAuthCommand()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Password = string.Empty;
    }

    public UpdateUserFromAuthCommand(int id, string firstName, string lastName, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
    }
}

