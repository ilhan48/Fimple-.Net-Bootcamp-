using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Hashing;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.UpdateFromAuth;

public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IAuthService _authService;

    public UpdateUserFromAuthCommandHandler(
        IUserRepository userRepository,
        IMapper mapper,
        UserBusinessRules userBusinessRules,
        IAuthService authService
    )
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _authService = authService;
    }

    public async Task<UpdatedUserFromAuthResponse> Handle(UpdateUserFromAuthCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserPasswordShouldBeMatched(user: user!, request.Password);
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user!.Id, user.Email);

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
        User updatedUser = await _userRepository.UpdateAsync(user!);

        UpdatedUserFromAuthResponse response = _mapper.Map<UpdatedUserFromAuthResponse>(updatedUser);
        response.AccessToken = await _authService.CreateAccessToken(user!);
        return response;
    }
}
