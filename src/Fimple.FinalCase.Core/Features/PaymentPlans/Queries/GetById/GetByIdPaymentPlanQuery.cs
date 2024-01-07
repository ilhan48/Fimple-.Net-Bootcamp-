using Fimple.FinalCase.Core.Features.PaymentPlans.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.PaymentPlans.Constants.PaymentPlansOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Queries.GetById;

public class GetByIdPaymentPlanQuery : IRequest<GetByIdPaymentPlanResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdPaymentPlanQueryHandler : IRequestHandler<GetByIdPaymentPlanQuery, GetByIdPaymentPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly PaymentPlanBusinessRules _paymentPlanBusinessRules;

        public GetByIdPaymentPlanQueryHandler(IMapper mapper, IPaymentPlanRepository paymentPlanRepository, PaymentPlanBusinessRules paymentPlanBusinessRules)
        {
            _mapper = mapper;
            _paymentPlanRepository = paymentPlanRepository;
            _paymentPlanBusinessRules = paymentPlanBusinessRules;
        }

        public async Task<GetByIdPaymentPlanResponse> Handle(GetByIdPaymentPlanQuery request, CancellationToken cancellationToken)
        {
            PaymentPlan? paymentPlan = await _paymentPlanRepository.GetAsync(predicate: pp => pp.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentPlanBusinessRules.PaymentPlanShouldExistWhenSelected(paymentPlan);

            GetByIdPaymentPlanResponse response = _mapper.Map<GetByIdPaymentPlanResponse>(paymentPlan);
            return response;
        }
    }
}