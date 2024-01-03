namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;
public class UpdatedOperationClaimResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdatedOperationClaimResponse()
    {
        Name = string.Empty;
    }

    public UpdatedOperationClaimResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
