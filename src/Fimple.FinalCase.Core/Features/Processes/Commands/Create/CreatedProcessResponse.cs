using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Create;

public class CreatedProcessResponse : IResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Time { get; set; }
}