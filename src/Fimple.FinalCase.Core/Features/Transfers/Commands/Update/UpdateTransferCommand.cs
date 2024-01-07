using Fimple.FinalCase.Core.Features.Transfers.Constants;
using Fimple.FinalCase.Core.Features.Transfers.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.Transfers.Constants.TransfersOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Transaction;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Update;

public class UpdateTransferCommand : IRequest<UpdatedTransferResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public decimal Amount { get; set; }
    public TransferStatus Status { get; set; }
    public short Max { get; set; }

    public string[] Roles => new[] { Admin, Write, TransfersOperationClaims.Update };

    public class UpdateTransferCommandHandler : IRequestHandler<UpdateTransferCommand, UpdatedTransferResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransferRepository _transferRepository;
        private readonly TransferBusinessRules _transferBusinessRules;

        public UpdateTransferCommandHandler(IMapper mapper, ITransferRepository transferRepository,
                                         TransferBusinessRules transferBusinessRules)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
            _transferBusinessRules = transferBusinessRules;
        }

        public async Task<UpdatedTransferResponse> Handle(UpdateTransferCommand request, CancellationToken cancellationToken)
        {
            Transfer? transfer = await _transferRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transferBusinessRules.TransferShouldExistWhenSelected(transfer);
            transfer = _mapper.Map(request, transfer);

            await _transferRepository.UpdateAsync(transfer!);

            UpdatedTransferResponse response = _mapper.Map<UpdatedTransferResponse>(transfer);
            return response;
        }
    }
}