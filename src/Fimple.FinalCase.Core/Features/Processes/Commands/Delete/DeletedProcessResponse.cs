using Fimple.FinalCase.Core.Utilities.Responses;
namespace Fimple.FinalCase.Core.Features.Processes.Commands.Delete;

public class DeletedProcessResponse : IResponse
{
    public int Id { get; set; }
}