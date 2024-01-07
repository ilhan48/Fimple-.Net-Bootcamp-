using Fimple.FinalCase.Core.Features.Users.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using MediatR;
using static Fimple.FinalCase.Core.Features.Users.Constants.UsersOperationClaims;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeletedUserResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UsersOperationClaims.Delete };

}
