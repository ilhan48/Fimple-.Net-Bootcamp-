using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.Transfers.Queries.GetList;

public class GetListTransferListItemDto
{
    public int Id { get; set; }
    public int SenderAccountId { get; set; }
    public int ReceiverAccountId { get; set; }
    public decimal Amount { get; set; }
    public TransferStatus Status { get; set; }
    public short Max { get; set; }
}