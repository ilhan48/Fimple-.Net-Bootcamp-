using MediatR;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.RefreshToken;

public partial class RefreshTokenCommand : IRequest<RefreshedTokensResponse>
{
    public string RefreshToken { get; set; }
    public string IpAddress { get; set; }

    public RefreshTokenCommand()
    {
        RefreshToken = string.Empty;
        IpAddress = string.Empty;
    }

    public RefreshTokenCommand(string refreshToken, string ipAddress)
    {
        RefreshToken = refreshToken;
        IpAddress = ipAddress;
    }
}
