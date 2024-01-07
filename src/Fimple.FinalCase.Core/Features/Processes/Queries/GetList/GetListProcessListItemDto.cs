using Fimple.FinalCase.Core.Enums;

namespace Fimple.FinalCase.Core.Features.Processes.Queries.GetList;

public class GetListProcessListItemDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    public decimal Amount { get; set; }
}