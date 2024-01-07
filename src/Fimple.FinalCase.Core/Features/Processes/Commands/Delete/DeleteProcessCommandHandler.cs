using Fimple.FinalCase.Core.Features.Processes.Rules;
using AutoMapper;
using MediatR;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Entities;

namespace Fimple.FinalCase.Core.Features.Processes.Commands.Delete;

public class DeleteProcessCommandHandler : IRequestHandler<DeleteProcessCommand, DeletedProcessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProcessRepository _processRepository;
        private readonly ProcessBusinessRules _processBusinessRules;

        public DeleteProcessCommandHandler(IMapper mapper, IProcessRepository processRepository,
                                         ProcessBusinessRules processBusinessRules)
        {
            _mapper = mapper;
            _processRepository = processRepository;
            _processBusinessRules = processBusinessRules;
        }

        public async Task<DeletedProcessResponse> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
        {
            Process? process = await _processRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _processBusinessRules.ProcessShouldExistWhenSelected(process);

            await _processRepository.DeleteAsync(process!);

            DeletedProcessResponse response = _mapper.Map<DeletedProcessResponse>(process);
            return response;
        }
    }