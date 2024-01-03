using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Utilities.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}

