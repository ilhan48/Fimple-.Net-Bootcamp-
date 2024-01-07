using Fimple.FinalCase.Core.Features.SupportTickets.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetById;

public class GetByIdSupportTicketQuery : IRequest<GetByIdSupportTicketResponse>
{
    public int Id { get; set; }

    public class GetByIdSupportTicketQueryHandler : IRequestHandler<GetByIdSupportTicketQuery, GetByIdSupportTicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISupportTicketRepository _supportTicketRepository;
        private readonly SupportTicketBusinessRules _supportTicketBusinessRules;

        public GetByIdSupportTicketQueryHandler(IMapper mapper, ISupportTicketRepository supportTicketRepository, SupportTicketBusinessRules supportTicketBusinessRules)
        {
            _mapper = mapper;
            _supportTicketRepository = supportTicketRepository;
            _supportTicketBusinessRules = supportTicketBusinessRules;
        }

        public async Task<GetByIdSupportTicketResponse> Handle(GetByIdSupportTicketQuery request, CancellationToken cancellationToken)
        {
            SupportTicket? supportTicket = await _supportTicketRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _supportTicketBusinessRules.SupportTicketShouldExistWhenSelected(supportTicket);

            GetByIdSupportTicketResponse response = _mapper.Map<GetByIdSupportTicketResponse>(supportTicket);
            return response;
        }
    }
}