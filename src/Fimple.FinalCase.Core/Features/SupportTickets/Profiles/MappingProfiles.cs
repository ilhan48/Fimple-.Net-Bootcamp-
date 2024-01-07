using Fimple.FinalCase.Core.Features.SupportTickets.Commands.Create;
using Fimple.FinalCase.Core.Features.SupportTickets.Commands.Delete;
using Fimple.FinalCase.Core.Features.SupportTickets.Commands.Update;
using Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetById;
using Fimple.FinalCase.Core.Features.SupportTickets.Queries.GetList;
using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.SupportTickets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SupportTicket, CreateSupportTicketCommand>().ReverseMap();
        CreateMap<SupportTicket, CreatedSupportTicketResponse>().ReverseMap();
        CreateMap<SupportTicket, UpdateSupportTicketCommand>().ReverseMap();
        CreateMap<SupportTicket, UpdatedSupportTicketResponse>().ReverseMap();
        CreateMap<SupportTicket, DeleteSupportTicketCommand>().ReverseMap();
        CreateMap<SupportTicket, DeletedSupportTicketResponse>().ReverseMap();
        CreateMap<SupportTicket, GetByIdSupportTicketResponse>().ReverseMap();
        CreateMap<SupportTicket, GetListSupportTicketListItemDto>().ReverseMap();
        CreateMap<IPaginate<SupportTicket>, GetListResponse<GetListSupportTicketListItemDto>>().ReverseMap();
    }
}