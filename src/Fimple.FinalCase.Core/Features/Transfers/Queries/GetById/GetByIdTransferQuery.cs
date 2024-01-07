using Fimple.FinalCase.Core.Features.Transfers.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.Transfers.Constants.TransfersOperationClaims;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Transfers.Queries.GetById;

public class GetByIdTransferQuery : IRequest<GetByIdTransferResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdTransferQueryHandler : IRequestHandler<GetByIdTransferQuery, GetByIdTransferResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITransferRepository _transferRepository;
        private readonly TransferBusinessRules _transferBusinessRules;

        public GetByIdTransferQueryHandler(IMapper mapper, ITransferRepository transferRepository, TransferBusinessRules transferBusinessRules)
        {
            _mapper = mapper;
            _transferRepository = transferRepository;
            _transferBusinessRules = transferBusinessRules;
        }

        public async Task<GetByIdTransferResponse> Handle(GetByIdTransferQuery request, CancellationToken cancellationToken)
        {
            Transfer? transfer = await _transferRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _transferBusinessRules.TransferShouldExistWhenSelected(transfer);

            GetByIdTransferResponse response = _mapper.Map<GetByIdTransferResponse>(transfer);
            return response;
        }
    }
}