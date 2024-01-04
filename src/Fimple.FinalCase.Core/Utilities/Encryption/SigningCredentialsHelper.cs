using Microsoft.IdentityModel.Tokens;

namespace Fimple.FinalCase.Core.Utilities.Encryption;

public static class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) =>
        new(securityKey, SecurityAlgorithms.HmacSha512Signature);
}
