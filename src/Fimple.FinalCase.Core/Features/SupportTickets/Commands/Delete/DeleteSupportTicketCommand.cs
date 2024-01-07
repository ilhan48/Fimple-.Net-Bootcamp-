using Fimple.FinalCase.Core.Features.SupportTickets.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Delete;

public class DeleteSupportTicketCommand : IRequest<DeletedSupportTicketResponse>
{
    public int Id { get; set; }

    public class DeleteSupportTicketCommandHandler : IRequestHandler<DeleteSupportTicketCommand, DeletedSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public DeleteSupportTicketCommandHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository,
                                         SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<DeletedSupportTicketResponse> Handle(DeleteSupportTicketCommand request, CancellationToken cancellationToken)
        {
            SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _supportTicketBusinessRules.SupportTicketShouldExistWhenSelected(supportTicket);

            await _supportTicketRepository.DeleteAsync(supportTicket!);

            DeletedSupportTicketResponse response = _mapper.Map<DeletedSupportTicketResponse>(supportTicket);
            return response;
        }
    }
}