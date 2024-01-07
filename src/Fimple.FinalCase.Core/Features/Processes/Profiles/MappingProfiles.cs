using Fimple.FinalCase.Core.Features.Processes.Commands.Create;
using Fimple.FinalCase.Core.Features.Processes.Commands.Delete;
using Fimple.FinalCase.Core.Features.Processes.Commands.Update;
using Fimple.FinalCase.Core.Features.Processes.Queries.GetById;
using Fimple.FinalCase.Core.Features.Processes.Queries.GetList;
using AutoMapper;
using System.Diagnostics;
using Fimple.FinalCase.Core.Utilities.Paging;

namespace Fimple.FinalCase.Core.Features.Processes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Process, CreateProcessCommand>().ReverseMap();
        CreateMap<Process, CreatedProcessResponse>().ReverseMap();
        CreateMap<Process, UpdateProcessCommand>().ReverseMap();
        CreateMap<Process, UpdatedProcessResponse>().ReverseMap();
        CreateMap<Process, DeleteProcessCommand>().ReverseMap();
        CreateMap<Process, DeletedProcessResponse>().ReverseMap();
        CreateMap<Process, GetByIdProcessResponse>().ReverseMap();
        CreateMap<Process, GetListProcessListItemDto>().ReverseMap();
        CreateMap<IPaginate<Process>, GetListResponse<GetListProcessListItemDto>>().ReverseMap();
    }
}