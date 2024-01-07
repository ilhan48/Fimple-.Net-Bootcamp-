using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Features.Processes.Constants;
using Fimple.FinalCase.Core.Utilities.Authorization;
using Fimple.FinalCase.Core.Utilities.Transaction;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Update;

public class UpdateProcessCommand : IRequest<UpdatedProcessResponse>,  ITransactionalRequest, ISecuredRequest
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public ProcessType Type { get; set; }
    public decimal Amount { get; set; }
    public string[] Roles => new[] {ProcessesOperationClaims.Admin};
}
