using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Create;

public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
{
    public CreateProcessCommandValidator()
    {
        RuleFor(c => c.AccountId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        
    }
}