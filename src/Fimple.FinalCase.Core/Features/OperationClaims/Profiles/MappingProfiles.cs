using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Create;
using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Delete;
using Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;
using Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetById;
using Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, GetByIdOperationClaimResponse>().ReverseMap();
        CreateMap<OperationClaim, GetListOperationClaimListItemDto>().ReverseMap();
        CreateMap<IPaginate<OperationClaim>, GetListResponse<GetListOperationClaimListItemDto>>().ReverseMap();
    }
}
