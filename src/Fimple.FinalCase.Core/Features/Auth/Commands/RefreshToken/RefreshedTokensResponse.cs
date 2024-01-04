using Fimple.FinalCase.Core.Utilities.JWT;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.RefreshToken;

public class RefreshedTokensResponse 
{
    public AccessToken AccessToken { get; set; }
    public Entities.Identity.RefreshToken RefreshToken { get; set; }

    public RefreshedTokensResponse()
    {
        AccessToken = null!;
        RefreshToken = null!;
    }

    public RefreshedTokensResponse(AccessToken accessToken, Entities.Identity.RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
