using Fimple.FinalCase.Core.Features.Processes.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Update;

public class UpdateProcessCommandHandler : IRequestHandler<UpdateProcessCommand, UpdatedProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _processRepository;
        private readonly ProcessBusinessRules _processBusinessRules;

        public UpdateProcessCommandHandler(IMapper mapper, IProcessRepository processRepository,
                                         ProcessBusinessRules processBusinessRules)
        {
            _mapper = mapper;
            _processRepository = processRepository;
            _processBusinessRules = processBusinessRules;
        }

        public async Task<UpdatedProcessResponse> Handle(UpdateProcessCommand request, CancellationToken cancellationToken)
        {
            Process? process = await _processRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _processBusinessRules.ProcessShouldExistWhenSelected(process);
            process = _mapper.Map(request, process);

            await _processRepository.UpdateAsync(process!);

            UpdatedProcessResponse response = _mapper.Map<UpdatedProcessResponse>(process);
            return response;
        }
    }