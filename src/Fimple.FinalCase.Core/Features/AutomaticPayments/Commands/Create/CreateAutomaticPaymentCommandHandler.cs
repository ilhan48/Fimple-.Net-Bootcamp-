using Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Create;

public class CreateAutomaticPaymentCommandHandler : IRequestHandler<CreateAutomaticPaymentCommand, CreatedAutomaticPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly AutomaticPaymentBusinessRules _automaticPaymentBusinessRules;

        public CreateAutomaticPaymentCommandHandler(IAccountRepository accountRepository, IMapper mapper, IAutomaticPaymentRepository automaticPaymentRepository,
                                         AutomaticPaymentBusinessRules automaticPaymentBusinessRules)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _automaticPaymentRepository = automaticPaymentRepository;
            _automaticPaymentBusinessRules = automaticPaymentBusinessRules;
        }

        public async Task<CreatedAutomaticPaymentResponse> Handle(CreateAutomaticPaymentCommand request, CancellationToken cancellationToken)
        {
            AutomaticPayment automaticPayment = _mapper.Map<AutomaticPayment>(request);
            Account? account = _accountRepository.GetAsync(predicate: a => a.UserId == request.UserId, enableTracking: false, cancellationToken: cancellationToken).Result;
            _automaticPaymentBusinessRules.CheckEnoughBalance(account, request.Amount);
            
            await _automaticPaymentRepository.AddAsync(automaticPayment);
            CreatedAutomaticPaymentResponse response = _mapper.Map<CreatedAutomaticPaymentResponse>(automaticPayment);
            return response;
        }
    }