using Fimple.FinalCase.Core.Features.CreditApplications.Constants;
using Fimple.FinalCase.Core.Features.CreditApplications.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.CreditApplications.Constants.CreditApplicationsOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Delete;

public class DeleteCreditApplicationCommand : IRequest<DeletedCreditApplicationResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, CreditApplicationsOperationClaims.Delete };

    public class DeleteCreditApplicationCommandHandler : IRequestHandler<DeleteCreditApplicationCommand, DeletedCreditApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly CreditApplicationBusinessRules _creditApplicationBusinessRules;

        public DeleteCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository,
                                         CreditApplicationBusinessRules creditApplicationBusinessRules)
        {
            _mapper = mapper;
            _creditApplicationRepository = creditApplicationRepository;
            _creditApplicationBusinessRules = creditApplicationBusinessRules;
        }

        public async Task<DeletedCreditApplicationResponse> Handle(DeleteCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            CreditApplication? creditApplication = await _creditApplicationRepository.GetAsync(predicate: ca => ca.Id == request.Id, cancellationToken: cancellationToken);
            await _creditApplicationBusinessRules.CreditApplicationShouldExistWhenSelected(creditApplication);

            await _creditApplicationRepository.DeleteAsync(creditApplication!);

            DeletedCreditApplicationResponse response = _mapper.Map<DeletedCreditApplicationResponse>(creditApplication);
            return response;
        }
    }
}