using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        DeletedUserResponse response = await _userService.DeleteAsync(request.Id);
        return response;
    }
}

