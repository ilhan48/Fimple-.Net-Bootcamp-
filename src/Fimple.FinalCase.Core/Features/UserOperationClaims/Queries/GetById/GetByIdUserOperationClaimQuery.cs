using MediatR;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetById;

public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimResponse>
{
    public int Id { get; set; }
}
