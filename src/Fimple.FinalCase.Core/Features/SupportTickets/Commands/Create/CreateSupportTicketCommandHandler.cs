using Fimple.FinalCase.Core.Features.SupportTickets.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;

public class CreateSupportTicketCommandHandler : IRequestHandler<CreateSupportTicketCommand, CreatedSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public CreateSupportTicketCommandHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository,
                                         SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<CreatedSupportTicketResponse> Handle(CreateSupportTicketCommand request, CancellationToken cancellationToken)
        {
            SupportTicket supportTicket = _mapper.Map<SupportTicket>(request);

            await _supportTicketRepository.AddAsync(supportTicket);

            CreatedSupportTicketResponse response = _mapper.Map<CreatedSupportTicketResponse>(supportTicket);
            return response;
        }
    }