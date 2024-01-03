namespace Fimple.FinalCase.Core.Features.Auth.Commands.RevokeToken;

public class RevokedTokenResponse
{
    public int Id { get; set; }
    public string Token { get; set; }

    public RevokedTokenResponse()
    {
        Token = string.Empty;
    }

    public RevokedTokenResponse(int id, string token)
    {
        Id = id;
        Token = token;
    }
}
