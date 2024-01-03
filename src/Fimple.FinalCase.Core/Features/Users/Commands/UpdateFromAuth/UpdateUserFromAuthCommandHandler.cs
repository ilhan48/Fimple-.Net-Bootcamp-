using AutoMapper;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Hashing;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.UpdateFromAuth;

public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthResponse>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IAuthService _authService;

    public UpdateUserFromAuthCommandHandler(
        IUserService userService,
        IMapper mapper,
        UserBusinessRules userBusinessRules,
        IAuthService authService
    )
    {
        _userService = userService;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _authService = authService;
    }

    public async Task<UpdatedUserFromAuthResponse> Handle(UpdateUserFromAuthCommand request, CancellationToken cancellationToken)
    {
        ListUserDto? existUser = await _userService.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(existUser!.Id, existUser.Email);
        var user = _mapper.Map<User>(existUser);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserPasswordShouldBeMatched(user: user!, request.Password);

        user = _mapper.Map(request, user);
        if (request.NewPassword != null && !string.IsNullOrWhiteSpace(request.NewPassword))
        {
            HashingHelper.CreatePasswordHash(
                request.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            user!.PasswordHash = passwordHash;
            user!.PasswordSalt = passwordSalt;
        }
        var updateUser = _mapper.Map<UpdateUserCommand>(user);
        UpdatedUserResponse updatedUser = await _userService.UpdateAsync(user.Id, updateUser!);

        UpdatedUserFromAuthResponse response = _mapper.Map<UpdatedUserFromAuthResponse>(updatedUser);
        response.AccessToken = await _authService.CreateAccessToken(user!);
        return response;
    }
}
