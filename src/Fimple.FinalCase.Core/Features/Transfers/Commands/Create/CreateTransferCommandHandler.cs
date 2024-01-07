using Fimple.FinalCase.Core.Features.Transfers.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Create;

public class CreateTransferCommandHandler : IRequestHandler<CreateTransferCommand, CreatedTransferResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransferRepository _transferRepository;
        private readonly TransferBusinessRules _transferBusinessRules;
        private readonly IAccountRepository _accountRepository;

        public CreateTransferCommandHandler(IAccountRepository accountRepository, IMapper mapper, ITransferRepository transferRepository,
                                         TransferBusinessRules transferBusinessRules)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _transferRepository = transferRepository;
            _transferBusinessRules = transferBusinessRules;
        }

        public async Task<CreatedTransferResponse> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            Transfer transfer = _mapper.Map<Transfer>(request);

            await _transferBusinessRules.CheckDailyMaxAmount(transfer);

            await _transferRepository.AddAsync(transfer);

            var sender = _accountRepository.GetAsync(predicate: s => s.Id == request.SenderAccountId);
            var receiver = _accountRepository.GetAsync(predicate: s => s.Id == request.ReceiverAccountId);

            sender.Result.Balance -= request.Amount;
            receiver.Result.Balance += request.Amount;

            _accountRepository.UpdateAsync(sender.Result);
            _accountRepository.UpdateAsync(receiver.Result);

            CreatedTransferResponse response = _mapper.Map<CreatedTransferResponse>(transfer);
            return response;
        }
    }