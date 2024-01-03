using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Queries.GetById;

public class GetByIdUserOperationClaimQuery : IRequest<GetByIdUserOperationClaimResponse>
{
    public int Id { get; set; }

    public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public GetByIdUserOperationClaimQueryHandler(
            IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules
        )
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<GetByIdUserOperationClaimResponse> Handle(
            GetByIdUserOperationClaimQuery request,
            CancellationToken cancellationToken
        )
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
                predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenSelected(userOperationClaim);

            GetByIdUserOperationClaimResponse userOperationClaimDto = _mapper.Map<GetByIdUserOperationClaimResponse>(userOperationClaim);
            return userOperationClaimDto;
        }
    }
}
