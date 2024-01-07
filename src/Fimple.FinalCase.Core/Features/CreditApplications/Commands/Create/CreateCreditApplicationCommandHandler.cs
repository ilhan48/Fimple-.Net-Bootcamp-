using Fimple.FinalCase.Core.Features.CreditApplications.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities.Identity;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommandHandler : IRequestHandler<CreateCreditApplicationCommand, CreatedCreditApplicationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private readonly CreditApplicationBusinessRules _creditApplicationBusinessRules;

        public CreateCreditApplicationCommandHandler(IMapper mapper, ICreditApplicationRepository creditApplicationRepository,
                                         CreditApplicationBusinessRules creditApplicationBusinessRules)
        {
            _mapper = mapper;
            _creditApplicationRepository = creditApplicationRepository;
            _creditApplicationBusinessRules = creditApplicationBusinessRules;
        }

        public async Task<CreatedCreditApplicationResponse> Handle(CreateCreditApplicationCommand request, CancellationToken cancellationToken)
        {
            CreditApplication creditApplication = _mapper.Map<CreditApplication>(request);

            await _creditApplicationBusinessRules.CheckStatusReject(request.ApplicantId);
            await _creditApplicationRepository.AddAsync(creditApplication);

            CreatedCreditApplicationResponse response = _mapper.Map<CreatedCreditApplicationResponse>(creditApplication);
            return response;
        }
    }