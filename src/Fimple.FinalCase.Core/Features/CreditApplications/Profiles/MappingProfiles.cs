using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;
using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Delete;
using Fimple.FinalCase.Core.Features.CreditApplications.Commands.Update;
using Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetById;
using Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreditApplication, CreateCreditApplicationCommand>().ReverseMap();
        CreateMap<CreditApplication, CreatedCreditApplicationResponse>().ReverseMap();
        CreateMap<CreditApplication, UpdateCreditApplicationCommand>().ReverseMap();
        CreateMap<CreditApplication, UpdatedCreditApplicationResponse>().ReverseMap();
        CreateMap<CreditApplication, DeleteCreditApplicationCommand>().ReverseMap();
        CreateMap<CreditApplication, DeletedCreditApplicationResponse>().ReverseMap();
        CreateMap<CreditApplication, GetByIdCreditApplicationResponse>().ReverseMap();
        CreateMap<CreditApplication, GetListCreditApplicationListItemDto>().ReverseMap();
        CreateMap<IPaginate<CreditApplication>, GetListResponse<GetListCreditApplicationListItemDto>>().ReverseMap();
    }
}