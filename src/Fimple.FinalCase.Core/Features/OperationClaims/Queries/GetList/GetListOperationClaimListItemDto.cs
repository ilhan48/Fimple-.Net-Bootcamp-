namespace Fimple.FinalCase.Core.Features.OperationClaims.Queries.GetList;

public class GetListOperationClaimListItemDto
{ 
    public int Id { get; set; }
    public string Name { get; set; }

    public GetListOperationClaimListItemDto()
    {
        Name = string.Empty;
    }

    public GetListOperationClaimListItemDto(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
