using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreatedUserResponse response = await _userService.AddAsync(request);
        return response;    
    }
}

