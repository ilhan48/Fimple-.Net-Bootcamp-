using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdatedUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UpdatedUserResponse response = await _userService.UpdateAsync(request.Id, request);
        return response;
    }
}

