using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Update;

public class UpdateTransferCommandValidator : AbstractValidator<UpdateTransferCommand>
{
    public UpdateTransferCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SenderAccountId).NotEmpty();
        RuleFor(c => c.ReceiverAccountId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Max).NotEmpty();
    }
}