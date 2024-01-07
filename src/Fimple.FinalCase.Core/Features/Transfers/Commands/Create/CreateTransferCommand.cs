using Fimple.FinalCase.Core.Features.Transfers.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Transaction;
using MediatR;
using static Fimple.FinalCase.Core.Features.Transfers.Constants.TransfersOperationClaims;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Create;

public class CreateTransferCommand : IRequest<CreatedTransferResponse>, ISecuredRequest, ITransactionalRequest
{
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public decimal Amount { get; set; }
    public Enums.TransferStatus Status { get; set; }
    public short Max { get; set; }

    public string[] Roles => new[] { Admin, Write, TransfersOperationClaims.Create };

}
