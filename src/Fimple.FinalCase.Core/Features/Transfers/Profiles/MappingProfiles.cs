using Fimple.FinalCase.Core.Features.Transfers.Commands.Create;
using Fimple.FinalCase.Core.Features.Transfers.Commands.Delete;
using Fimple.FinalCase.Core.Features.Transfers.Commands.Update;
using Fimple.FinalCase.Core.Features.Transfers.Queries.GetById;
using Fimple.FinalCase.Core.Features.Transfers.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.Transfers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Transfer, CreateTransferCommand>().ReverseMap();
        CreateMap<Transfer, CreatedTransferResponse>().ReverseMap();
        CreateMap<Transfer, UpdateTransferCommand>().ReverseMap();
        CreateMap<Transfer, UpdatedTransferResponse>().ReverseMap();
        CreateMap<Transfer, DeleteTransferCommand>().ReverseMap();
        CreateMap<Transfer, DeletedTransferResponse>().ReverseMap();
        CreateMap<Transfer, GetByIdTransferResponse>().ReverseMap();
        CreateMap<Transfer, GetListTransferListItemDto>().ReverseMap();
        CreateMap<IPaginate<Transfer>, GetListResponse<GetListTransferListItemDto>>().ReverseMap();
    }
}