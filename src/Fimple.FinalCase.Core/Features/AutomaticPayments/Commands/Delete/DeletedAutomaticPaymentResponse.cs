using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Commands.Delete;

public class DeletedAutomaticPaymentResponse : IResponse
{
    public int Id { get; set; }
}