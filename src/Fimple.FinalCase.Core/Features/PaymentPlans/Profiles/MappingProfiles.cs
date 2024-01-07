using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;
using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Delete;
using Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Update;
using Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetById;
using Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PaymentPlan, CreatePaymentPlanCommand>().ReverseMap();
        CreateMap<PaymentPlan, CreatedPaymentPlanResponse>().ReverseMap();
        CreateMap<PaymentPlan, UpdatePaymentPlanCommand>().ReverseMap();
        CreateMap<PaymentPlan, UpdatedPaymentPlanResponse>().ReverseMap();
        CreateMap<PaymentPlan, DeletePaymentPlanCommand>().ReverseMap();
        CreateMap<PaymentPlan, DeletedPaymentPlanResponse>().ReverseMap();
        CreateMap<PaymentPlan, GetByIdPaymentPlanResponse>().ReverseMap();
        CreateMap<PaymentPlan, GetListPaymentPlanListItemDto>().ReverseMap();
        CreateMap<IPaginate<PaymentPlan>, GetListResponse<GetListPaymentPlanListItemDto>>().ReverseMap();
    }
}