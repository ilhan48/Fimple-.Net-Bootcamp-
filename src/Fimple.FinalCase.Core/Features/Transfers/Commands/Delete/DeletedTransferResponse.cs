using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Delete;

public class DeletedTransferResponse : IResponse
{
    public int Id { get; set; }
}