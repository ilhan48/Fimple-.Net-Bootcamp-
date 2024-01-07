using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Update;

public class UpdatedTransferResponse : IResponse
{
    public int Id { get; set; }
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public decimal Amount { get; set; }
    public TransferStatus Status { get; set; }
    public short Max { get; set; }
}