using Fimple.FinalCase.Core.Features.PaymentPlans.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.PaymentPlans.Commands.Create;

public class CreatePaymentPlanCommandHandler : IRequestHandler<CreatePaymentPlanCommand, CreatedPaymentPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentPlanRepository _paymentPlanRepository;
        private readonly PaymentPlanBusinessRules _paymentPlanBusinessRules;

        public CreatePaymentPlanCommandHandler(IMapper mapper, IPaymentPlanRepository paymentPlanRepository,
                                         PaymentPlanBusinessRules paymentPlanBusinessRules)
        {
            _mapper = mapper;
            _paymentPlanRepository = paymentPlanRepository;
            _paymentPlanBusinessRules = paymentPlanBusinessRules;
        }

        public async Task<CreatedPaymentPlanResponse> Handle(CreatePaymentPlanCommand request, CancellationToken cancellationToken)
        {
            PaymentPlan paymentPlan = _mapper.Map<PaymentPlan>(request);

            await _paymentPlanRepository.AddAsync(paymentPlan);

            CreatedPaymentPlanResponse response = _mapper.Map<CreatedPaymentPlanResponse>(paymentPlan);
            return response;
        }
    }