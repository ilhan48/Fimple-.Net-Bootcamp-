using Fimple.FinalCase.Core.Utilities.JWT;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{
    public AccessToken? AccessToken { get; set; }
    public Entities.Identity.RefreshToken? RefreshToken { get; set; }

    public LoggedHttpResponse ToHttpResponse() =>
        new() { AccessToken = AccessToken };

    public class LoggedHttpResponse
    {
        public AccessToken? AccessToken { get; set; }
    }
}
