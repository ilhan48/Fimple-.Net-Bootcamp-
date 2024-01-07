using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Paging;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Processes.Queries.GetList;

public class GetListProcessQuery : IRequest<GetListResponse<GetListProcessListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProcessQueryHandler : IRequestHandler<GetListProcessQuery, GetListResponse<GetListProcessListItemDto>>
    {
        private readonly IProcessRepository _processRepository;
        private readonly IMapper _mapper;

        public GetListProcessQueryHandler(IProcessRepository processRepository, IMapper mapper)
        {
            _processRepository = processRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProcessListItemDto>> Handle(GetListProcessQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Process> processes = await _processRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProcessListItemDto> response = _mapper.Map<GetListResponse<GetListProcessListItemDto>>(processes);
            return response;
        }
    }
}