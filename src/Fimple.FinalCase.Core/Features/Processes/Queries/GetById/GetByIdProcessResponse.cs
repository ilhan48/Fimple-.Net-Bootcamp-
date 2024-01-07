using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Processes.Queries.GetById;

public class GetByIdProcessResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    public decimal Amount { get; set; }
}