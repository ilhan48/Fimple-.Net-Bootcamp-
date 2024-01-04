using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Create;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Delete;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Update;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetById;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetList;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, GetByIdUserOperationClaimResponse>().ReverseMap();
        CreateMap<UserOperationClaim, GetListUserOperationClaimListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimListItemDto>>().ReverseMap();
    }
}
