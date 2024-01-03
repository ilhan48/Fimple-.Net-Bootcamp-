using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Auth.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.JWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fimple.FinalCase.Core.Services;

public class AuthService : IAuthService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly TokenOptions _tokenOptions;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public AuthService(
        IUserOperationClaimRepository userOperationClaimRepository,
        IRefreshTokenRepository refreshTokenRepository,
        ITokenHelper tokenHelper,
        IConfiguration configuration,
        AuthBusinessRules authBusinessRules
    )
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _tokenHelper = tokenHelper;
        _authBusinessRules = authBusinessRules;

        const string tokenOptionsConfigurationSection = "TokenOptions";
        _tokenOptions =
            configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration");
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IList<OperationClaim> operationClaims = await _userOperationClaimRepository
            .Query()
            .AsNoTracking()
            .Where(p => p.Id == user.Id)
            .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
            .ToListAsync();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task DeleteOldRefreshTokens(int userId)
    {
        List<RefreshToken> refreshTokens = await _refreshTokenRepository
            .Query()
            .AsNoTracking()
            .Where(
                r =>
                    r.UserId == userId
                    && r.Revoked == null
                    && r.Expires >= DateTime.UtcNow
                    && r.CreatedAt.AddDays(_tokenOptions.RefreshTokenTTL) <= DateTime.UtcNow
            )
            .ToListAsync();

        await _refreshTokenRepository.DeleteRangeAsync(refreshTokens);
    }

    public async Task<RefreshToken?> GetRefreshTokenByToken(string token)
    {
        RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(predicate: r => r.Token == token);
        return refreshToken;
    }

    public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null)
    {
        refreshToken.Revoked = DateTime.UtcNow;
        refreshToken.RevokedByIp = ipAddress;
        refreshToken.ReasonRevoked = reason;
        refreshToken.ReplacedByToken = replacedByToken;
        await _refreshTokenRepository.UpdateAsync(refreshToken);
    }

    public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
    {
        RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        await RevokeRefreshToken(refreshToken, ipAddress, reason: "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
    {
        RefreshToken? childToken = await _refreshTokenRepository.GetAsync(predicate: r => r.Token == refreshToken.ReplacedByToken);

        if (childToken?.Revoked != null && childToken.Expires <= DateTime.UtcNow)
            await RevokeRefreshToken(childToken, ipAddress, reason);
        else
            await RevokeDescendantRefreshTokens(refreshToken: childToken!, ipAddress, reason);
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }
}
