using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Create;

public class CreatedOperationClaimResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CreatedOperationClaimResponse()
    {
        Name = string.Empty;
    }

    public CreatedOperationClaimResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
