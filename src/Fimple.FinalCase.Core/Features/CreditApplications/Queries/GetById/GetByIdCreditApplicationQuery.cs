using Fimple.FinalCase.Core.Features.CreditApplications.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.CreditApplications.Constants.CreditApplicationsOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Queries.GetById;

public class GetByIdCreditApplicationQuery : IRequest<GetByIdCreditApplicationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdCreditApplicationQueryHandler : IRequestHandler<GetByIdCreditApplicationQuery, GetByIdCreditApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly CreditApplicationBusinessRules _creditApplicationBusinessRules;

        public GetByIdCreditApplicationQueryHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository, CreditApplicationBusinessRules creditApplicationBusinessRules)
        {
            _mapper = mapper;
            _creditApplicationRepository = creditApplicationRepository;
            _creditApplicationBusinessRules = creditApplicationBusinessRules;
        }

        public async Task<GetByIdCreditApplicationResponse> Handle(GetByIdCreditApplicationQuery request, CancellationToken cancellationToken)
        {
            CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _creditApplicationBusinessRules.CreditApplicationShouldExistWhenSelected(creditApplication);

            GetByIdCreditApplicationResponse response = _mapper.Map<GetByIdCreditApplicationResponse>(creditApplication);
            return response;
        }
    }
}