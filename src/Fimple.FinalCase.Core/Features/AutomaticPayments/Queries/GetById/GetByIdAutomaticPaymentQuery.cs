using Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.AutomaticPayments.Constants.AutomaticPaymentsOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetById;

public class GetByIdAutomaticPaymentQuery : IRequest<GetByIdAutomaticPaymentResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdAutomaticPaymentQueryHandler : IRequestHandler<GetByIdAutomaticPaymentQuery, GetByIdAutomaticPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
        private readonly AutomaticPaymentBusinessRules _automaticPaymentBusinessRules;

        public GetByIdAutomaticPaymentQueryHandler(IMapper mapper, IAutomaticPaymentRepository automaticPaymentRepository, AutomaticPaymentBusinessRules automaticPaymentBusinessRules)
        {
            _mapper = mapper;
            _automaticPaymentRepository = automaticPaymentRepository;
            _automaticPaymentBusinessRules = automaticPaymentBusinessRules;
        }

        public async Task<GetByIdAutomaticPaymentResponse> Handle(GetByIdAutomaticPaymentQuery request, CancellationToken cancellationToken)
        {
            AutomaticPayment? automaticPayment = await _automaticPaymentRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            await _automaticPaymentBusinessRules.AutomaticPaymentShouldExistWhenSelected(automaticPayment);

            GetByIdAutomaticPaymentResponse response = _mapper.Map<GetByIdAutomaticPaymentResponse>(automaticPayment);
            return response;
        }
    }
}