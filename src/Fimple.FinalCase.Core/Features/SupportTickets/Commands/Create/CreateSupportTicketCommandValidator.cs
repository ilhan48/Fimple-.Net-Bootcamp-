using FluentValidation;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommandValidator : AbstractValidator<CreateSupportTicketCommand>
{
    public CreateSupportTicketCommandValidator()
    {
        RuleFor(c => c.AskingId).NotEmpty();
        RuleFor(c => c.Issue).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}