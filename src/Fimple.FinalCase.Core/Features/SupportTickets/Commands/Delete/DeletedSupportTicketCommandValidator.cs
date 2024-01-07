using FluentValidation;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Delete;

public class DeleteSupportTicketCommandValidator : AbstractValidator<DeleteSupportTicketCommand>
{
    public DeleteSupportTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}