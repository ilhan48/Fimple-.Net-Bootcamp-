using FluentValidation;

namespace Fimple.FinalCase.Core.Features.Transfers.Commands.Create;

public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
{
    public CreateTransferCommandValidator()
    {
        RuleFor(c => c.SenderAccountId).NotEmpty();
        RuleFor(c => c.ReceiverAccountId).NotEmpty();
        RuleFor(c => c.Amount).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Max).NotEmpty();
    }
}