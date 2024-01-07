using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;
using static Fimple.FinalCase.Core.Features.PaymentPlans.Constants.PaymentPlansOperationClaims;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetList;

public class GetListPaymentPlanQuery : IRequest<GetListResponse<GetListPaymentPlanListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetListPaymentPlanQueryHandler : IRequestHandler<GetListPaymentPlanQuery, GetListResponse<GetListPaymentPlanListItemDto>>
    {
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly IMapper _mapper;

        public GetListPaymentPlanQueryHandler(IPaymentPlanRepository paymentPlanRepository, IMapper mapper)
        {
            _paymentPlanRepository = paymentPlanRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPaymentPlanListItemDto>> Handle(GetListPaymentPlanQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentPlan> paymentPlans = await _paymentPlanRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPaymentPlanListItemDto> response = _mapper.Map<GetListResponse<GetListPaymentPlanListItemDto>>(paymentPlans);
            return response;
        }
    }
}