using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.CreditApplications.Commands.Delete;

public class DeletedCreditApplicationResponse : IResponse
{
    public int Id { get; set; }
}