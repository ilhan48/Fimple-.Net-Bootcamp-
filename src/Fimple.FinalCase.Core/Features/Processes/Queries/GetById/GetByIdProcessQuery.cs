using Fimple.FinalCase.Core.Features.Processes.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Processes.Queries.GetById;

public class GetByIdProcessQuery : IRequest<GetByIdProcessResponse>
{
    public int Id { get; set; }

    public class GetByIdProcessQueryHandler : IRequestHandler<GetByIdProcessQuery, GetByIdProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _processRepository;
        private readonly ProcessBusinessRules _processBusinessRules;

        public GetByIdProcessQueryHandler(IMapper mapper, IProcessRepository processRepository, ProcessBusinessRules processBusinessRules)
        {
            _mapper = mapper;
            _processRepository = processRepository;
            _processBusinessRules = processBusinessRules;
        }

        public async Task<GetByIdProcessResponse> Handle(GetByIdProcessQuery request, CancellationToken cancellationToken)
        {
            Process? process = await _processRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _processBusinessRules.ProcessShouldExistWhenSelected(process);

            GetByIdProcessResponse response = _mapper.Map<GetByIdProcessResponse>(process);
            return response;
        }
    }
}