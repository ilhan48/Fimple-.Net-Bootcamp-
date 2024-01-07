using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimResponse>, ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { Admin, Write, Add };

    public class CreateUserOperationClaimCommandHandler
        : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public CreateUserOperationClaimCommandHandler(
            IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules
        )
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<CreatedUserOperationClaimResponse> Handle(
            CreateUserOperationClaimCommand request,
            CancellationToken cancellationToken
        )
        {
            await _userOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
                request.UserId,
                request.OperationClaimId
            );
            UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);

            CreatedUserOperationClaimResponse createdUserOperationClaimDto = _mapper.Map<CreatedUserOperationClaimResponse>(
                createdUserOperationClaim
            );
            return createdUserOperationClaimDto;
        }
    }
}
