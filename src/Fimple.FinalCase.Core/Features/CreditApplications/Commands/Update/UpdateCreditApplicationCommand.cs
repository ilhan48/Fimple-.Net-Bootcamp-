using Fimple.FinalCase.Core.Features.CreditApplications.Constants;
using Fimple.FinalCase.Core.Features.CreditApplications.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.CreditApplications.Constants.CreditApplicationsOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Update;

public class UpdateCreditApplicationCommand : IRequest<UpdatedCreditApplicationResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public decimal RequestedAmount { get; set; }
    public CreditApplicationStatus Status { get; set; }

    public string[] Roles => new[] { Admin, Write, CreditApplicationsOperationClaims.Update };

    public class UpdateCreditApplicationCommandHandler : IRequestHandler<UpdateCreditApplicationCommand, UpdatedCreditApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly CreditApplicationBusinessRules _creditApplicationBusinessRules;

        public UpdateCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository,
                                         CreditApplicationBusinessRules creditApplicationBusinessRules)
        {
            _mapper = mapper;
            _creditApplicationRepository = creditApplicationRepository;
            _creditApplicationBusinessRules = creditApplicationBusinessRules;
        }

        public async Task<UpdatedCreditApplicationResponse> Handle(UpdateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _creditApplicationBusinessRules.CreditApplicationShouldExistWhenSelected(creditApplication);
            creditApplication = _mapper.Map(request, creditApplication);

            await _creditApplicationRepository.UpdateAsync(creditApplication!);

            UpdatedCreditApplicationResponse response = _mapper.Map<UpdatedCreditApplicationResponse>(creditApplication);
            return response;
        }
    }
}