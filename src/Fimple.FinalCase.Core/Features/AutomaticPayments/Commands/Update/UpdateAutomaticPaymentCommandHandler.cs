using Fimple.FinalCase.Core.Features.AutomaticPayments.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Update;

public class UpdateAutomaticPaymentCommandHandler : IRequestHandler<UpdateAutomaticPaymentCommand, UpdatedAutomaticPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAutomaticPaymentRepository _automaticPaymentRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly AutomaticPaymentBusinessRules _automaticPaymentBusinessRules;

        public UpdateAutomaticPaymentCommandHandler(IAccountRepository accountRepository, IMapper mapper, IAutomaticPaymentRepository automaticPaymentRepository,
                                         AutomaticPaymentBusinessRules automaticPaymentBusinessRules)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _automaticPaymentRepository = automaticPaymentRepository;
            _automaticPaymentBusinessRules = automaticPaymentBusinessRules;
        }

        public async Task<UpdatedAutomaticPaymentResponse> Handle(UpdateAutomaticPaymentCommand request, CancellationToken cancellationToken)
        {
            AutomaticPayment? automaticPayment = await _automaticPaymentRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            Account? account = _accountRepository.GetAsync(predicate: a => a.UserId == request.UserId, enableTracking: false, cancellationToken: cancellationToken).Result;
            
            await _automaticPaymentBusinessRules.CheckEnoughBalance(account, request.Amount);
            await _automaticPaymentBusinessRules.AutomaticPaymentShouldExistWhenSelected(automaticPayment);
            
            automaticPayment = _mapper.Map(request, automaticPayment);
            await _automaticPaymentRepository.UpdateAsync(automaticPayment!);

            UpdatedAutomaticPaymentResponse response = _mapper.Map<UpdatedAutomaticPaymentResponse>(automaticPayment);
            return response;
        }
    }