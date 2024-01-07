using Fimple.FinalCase.Core.Features.SupportTickets.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Update;

public class UpdateSupportTicketCommandHandler : IRequestHandler<UpdateSupportTicketCommand, UpdatedSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public UpdateSupportTicketCommandHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository,
                                         SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<UpdatedSupportTicketResponse> Handle(UpdateSupportTicketCommand request, CancellationToken cancellationToken)
        {
            SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _supportTicketBusinessRules.SupportTicketShouldExistWhenSelected(supportTicket);
            supportTicket = _mapper.Map(request, supportTicket);

            await _supportTicketRepository.UpdateAsync(supportTicket!);

            UpdatedSupportTicketResponse response = _mapper.Map<UpdatedSupportTicketResponse>(supportTicket);
            return response;
        }
    }