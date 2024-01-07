using Fimple.FinalCase.Core.Features.Processes.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Transaction;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Delete;

public class DeleteProcessCommand : IRequest<DeletedProcessResponse>, ITransactionalRequest, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] {ProcessesOperationClaims.Admin};

}
