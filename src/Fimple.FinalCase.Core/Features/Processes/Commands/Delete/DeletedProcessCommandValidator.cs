using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Delete;

public class DeleteProcessCommandValidator : AbstractValidator<DeleteProcessCommand>
{
    public DeleteProcessCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}