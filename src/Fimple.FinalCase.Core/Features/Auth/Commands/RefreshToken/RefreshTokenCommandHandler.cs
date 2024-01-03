using AutoMapper;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Auth.Rules;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.JWT;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshedTokensResponse>
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IMapper _mapper;

    public RefreshTokenCommandHandler(IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules, IMapper mapper)
    {
        _authService = authService;
        _userService = userService;
        _authBusinessRules = authBusinessRules;
        _mapper = mapper;
    }

    public async Task<RefreshedTokensResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        Fimple.FinalCase.Core.Entities.Identity.RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefreshToken);
        await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

        if (refreshToken!.Revoked != null)
            await _authService.RevokeDescendantRefreshTokens(
                refreshToken,
                request.IpAddress,
                reason: $"Attempted reuse of revoked ancestor token: {refreshToken.Token}"
            );
        await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

        ListUserDto? existUser = await _userService.GetAsync(predicate: u => u.Id == refreshToken.UserId, cancellationToken: cancellationToken);
        var user = _mapper.Map<User>(existUser);
        await _authBusinessRules.UserShouldBeExistsWhenSelected(user);

        Fimple.FinalCase.Core.Entities.Identity.RefreshToken newRefreshToken = await _authService.RotateRefreshToken(
            user: user!,
            refreshToken,
            request.IpAddress
        );
        Fimple.FinalCase.Core.Entities.Identity.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);
        await _authService.DeleteOldRefreshTokens(refreshToken.UserId);

        AccessToken createdAccessToken = await _authService.CreateAccessToken(user!);

        RefreshedTokensResponse refreshedTokensResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
        return refreshedTokensResponse;
    }
}

