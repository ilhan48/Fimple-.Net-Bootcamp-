using Fimple.FinalCase.Core.Features.Transfers.Constants;
using Fimple.FinalCase.Core.Features.Transfers.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.Transfers.Constants.TransfersOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Transaction;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Delete;

public class DeleteTransferCommand : IRequest<DeletedTransferResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, TransfersOperationClaims.Delete };

    public class DeleteTransferCommandHandler : IRequestHandler<DeleteTransferCommand, DeletedTransferResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransferRepository _transferRepository;
        private readonly TransferBusinessRules _transferBusinessRules;

        public DeleteTransferCommandHandler(IMapper mapper, ITransferRepository transferRepository,
                                         TransferBusinessRules transferBusinessRules)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
            _transferBusinessRules = transferBusinessRules;
        }

        public async Task<DeletedTransferResponse> Handle(DeleteTransferCommand request, CancellationToken cancellationToken)
        {
            Transfer? transfer = await _transferRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transferBusinessRules.TransferShouldExistWhenSelected(transfer);

            await _transferRepository.DeleteAsync(transfer!);

            DeletedTransferResponse response = _mapper.Map<DeletedTransferResponse>(transfer);
            return response;
        }
    }
}