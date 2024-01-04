using MediatR;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.RevokeToken;

public partial class RevokeTokenCommand : IRequest<RevokedTokenResponse>
{
    public string Token { get; set; }
    public string IpAddress { get; set; }

    public RevokeTokenCommand()
    {
        Token = string.Empty;
        IpAddress = string.Empty;
    }

    public RevokeTokenCommand(string token, string ipAddress)
    {
        Token = token;
        IpAddress = ipAddress;
    }
}
