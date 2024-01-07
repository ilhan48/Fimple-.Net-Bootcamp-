using Fimple.FinalCase.Core.Features.PaymentPlans.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Update;

public class UpdatePaymentPlanCommandHandler : IRequestHandler<UpdatePaymentPlanCommand, UpdatedPaymentPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly PaymentPlanBusinessRules _paymentPlanBusinessRules;

        public UpdatePaymentPlanCommandHandler(IMapper mapper, IPaymentPlanRepository paymentPlanRepository,
                                         PaymentPlanBusinessRules paymentPlanBusinessRules)
        {
            _mapper = mapper;
            _paymentPlanRepository = paymentPlanRepository;
            _paymentPlanBusinessRules = paymentPlanBusinessRules;
        }

        public async Task<UpdatedPaymentPlanResponse> Handle(UpdatePaymentPlanCommand request, CancellationToken cancellationToken)
        {
            PaymentPlan? paymentPlan = await _paymentPlanRepository.GetAsync(predicate: pp => pp.Id == request.Id, cancellationToken: cancellationToken);
            await _paymentPlanBusinessRules.PaymentPlanShouldExistWhenSelected(paymentPlan);
            paymentPlan = _mapper.Map(request, paymentPlan);

            await _paymentPlanRepository.UpdateAsync(paymentPlan!);

            UpdatedPaymentPlanResponse response = _mapper.Map<UpdatedPaymentPlanResponse>(paymentPlan);
            return response;
        }
    }