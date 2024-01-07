using Fimple.FinalCase.Core.Features.Auth.Commands.RevokeToken;
using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.Auth.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenResponse>().ReverseMap();
    }
}
