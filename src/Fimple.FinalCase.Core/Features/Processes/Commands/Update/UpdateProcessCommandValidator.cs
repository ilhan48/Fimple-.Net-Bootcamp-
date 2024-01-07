using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Update;

public class UpdateProcessCommandValidator : AbstractValidator<UpdateProcessCommand>
{
    public UpdateProcessCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
    }
}