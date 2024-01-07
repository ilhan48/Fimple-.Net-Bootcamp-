using FluentValidation;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Update;

public class UpdateSupportTicketCommandValidator : AbstractValidator<UpdateSupportTicketCommand>
{
    public UpdateSupportTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AskingId).NotEmpty();
        RuleFor(c => c.AnsweringId).NotEmpty();
        RuleFor(c => c.Issue).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}