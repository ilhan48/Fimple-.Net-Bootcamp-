using FluentValidation;

namespace Fimple.FinalCase.Core.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
    }
}
