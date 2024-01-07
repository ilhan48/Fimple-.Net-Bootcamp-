using Fimple.FinalCase.Core.Features.Processes.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Create;

public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, CreatedProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _processRepository;
        private readonly ProcessBusinessRules _processBusinessRules;
        private readonly IAccountRepository _accountRepository;

        public CreateProcessCommandHandler(IAccountRepository accountRepository, IMapper mapper, IProcessRepository processRepository,
                                         ProcessBusinessRules processBusinessRules)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _processRepository = processRepository;
            _processBusinessRules = processBusinessRules;
        }

        public async Task<CreatedProcessResponse> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            Process process = _mapper.Map<Process>(request);
            Account? account = _accountRepository.GetAsync(
                predicate: a => a.Id == request.AccountId,
                enableTracking: false,
                cancellationToken: cancellationToken
            ).Result;
            

            if (request.Type == ProcessType.Withdrawal)
            {
                _processBusinessRules.CheckEnoughBalance(account, request.Amount);
                account.Balance -= request.Amount;
                await _accountRepository.UpdateAsync(account); 
            }
            else
            {
                account.Balance += request.Amount;
                await _accountRepository.UpdateAsync(account);
            }

            await _processRepository.AddAsync(process);
            
            CreatedProcessResponse response = _mapper.Map<CreatedProcessResponse>(process);
            response.Time = process.CreatedAt; 
            return response;
        }
    }