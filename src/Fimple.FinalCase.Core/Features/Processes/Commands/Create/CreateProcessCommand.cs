using Fimple.FinalCase.Core.Features.Processes.Constants;
using MediatR;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Transaction;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Create;

public class CreateProcessCommand : IRequest<CreatedProcessResponse>, ITransactionalRequest, ISecuredRequest
{
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    public decimal Amount { get; set; }
    public string[] Roles => new [] {ProcessesOperationClaims.Create, ProcessesOperationClaims.Admin};
}
