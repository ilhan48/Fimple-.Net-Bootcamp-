using Fimple.FinalCase.Core.Utilities.JWT;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.Register;

public class RegisteredResponse 
{
    public AccessToken AccessToken { get; set; }
    public Entities.Identity.RefreshToken RefreshToken { get; set; }

    public RegisteredResponse()
    {
        AccessToken = null!;
        RefreshToken = null!;
    }

    public RegisteredResponse(AccessToken accessToken, Entities.Identity.RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
