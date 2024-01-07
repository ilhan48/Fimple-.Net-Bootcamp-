using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Create;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Update;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetById;
using Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AutomaticPayment, CreateAutomaticPaymentCommand>().ReverseMap();
        CreateMap<AutomaticPayment, CreatedAutomaticPaymentResponse>().ReverseMap();
        CreateMap<AutomaticPayment, UpdateAutomaticPaymentCommand>().ReverseMap();
        CreateMap<AutomaticPayment, UpdatedAutomaticPaymentResponse>().ReverseMap();
        CreateMap<AutomaticPayment, DeleteAutomaticPaymentCommand>().ReverseMap();
        CreateMap<AutomaticPayment, DeletedAutomaticPaymentResponse>().ReverseMap();
        CreateMap<AutomaticPayment, GetByIdAutomaticPaymentResponse>().ReverseMap();
        CreateMap<AutomaticPayment, GetListAutomaticPaymentListItemDto>().ReverseMap();
        CreateMap<IPaginate<AutomaticPayment>, GetListResponse<GetListAutomaticPaymentListItemDto>>().ReverseMap();
    }
}