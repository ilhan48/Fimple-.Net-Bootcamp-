using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Delete;

public class DeleteTransferCommandValidator : AbstractValidator<DeleteTransferCommand>
{
    public DeleteTransferCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}