using Fimple.FinalCase.Core.Features.PaymentPlans.Constants;
using Fimple.FinalCase.Core.Features.PaymentPlans.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.PaymentPlans.Constants.PaymentPlansOperationClaims;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Delete;

public class DeletePaymentPlanCommand : IRequest<DeletedPaymentPlanResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, PaymentPlansOperationClaims.Delete };

    public class DeletePaymentPlanCommandHandler : IRequestHandler<DeletePaymentPlanCommand, DeletedPaymentPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly PaymentPlanBusinessRules _paymentPlanBusinessRules;

        public DeletePaymentPlanCommandHandler(IMapper mapper, IPaymentPlanRepository paymentPlanRepository,
                                         PaymentPlanBusinessRules paymentPlanBusinessRules)
        {
            _mapper = mapper;
            _paymentPlanRepository = paymentPlanRepository;
            _paymentPlanBusinessRules = paymentPlanBusinessRules;
        }

        public async Task<DeletedPaymentPlanResponse> Handle(DeletePaymentPlanCommand request, CancellationToken cancellationToken)
        {
            PaymentPlan? paymentPlan = await _paymentPlanRepository.GetAsync(predicate: pp => pp.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentPlanBusinessRules.PaymentPlanShouldExistWhenSelected(paymentPlan);

            await _paymentPlanRepository.DeleteAsync(paymentPlan!);

            DeletedPaymentPlanResponse response = _mapper.Map<DeletedPaymentPlanResponse>(paymentPlan);
            return response;
        }
    }
}