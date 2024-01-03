using AutoMapper;
using Fimple.FinalCase.Core.Features.Auth.Rules;
using Fimple.FinalCase.Core.Ports.Driving;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.RevokeToken;

public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokedTokenResponse>
    {
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public RevokeTokenCommandHandler(IAuthService authService, AuthBusinessRules authBusinessRules, IMapper mapper)
        {
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _mapper = mapper;
        }

        public async Task<RevokedTokenResponse> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            Entities.Identity.RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.Token);
            await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
            await _authBusinessRules.RefreshTokenShouldBeActive(refreshToken!);

            await _authService.RevokeRefreshToken(token: refreshToken!, request.IpAddress, reason: "Revoked without replacement");

            RevokedTokenResponse revokedTokenResponse = _mapper.Map<RevokedTokenResponse>(refreshToken);
            return revokedTokenResponse;
        }
    }

