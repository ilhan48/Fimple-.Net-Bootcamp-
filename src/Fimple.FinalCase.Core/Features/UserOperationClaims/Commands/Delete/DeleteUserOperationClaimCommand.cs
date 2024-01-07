using Fimple.FinalCase.Core.Features.UserOperationClaims.Constants;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using AutoMapper;
using MediatR;
using static Fimple.FinalCase.Core.Features.UserOperationClaims.Constants.UserOperationClaimsOperationClaims;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Authorization;

namespace Fimple.FinalCase.Core.Features.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UserOperationClaimsOperationClaims.Delete };

    public class DeleteUserOperationClaimCommandHandler
        : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

        public DeleteUserOperationClaimCommandHandler(
            IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper,
            UserOperationClaimBusinessRules userOperationClaimBusinessRules
        )
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
        }

        public async Task<DeletedUserOperationClaimResponse> Handle(
            DeleteUserOperationClaimCommand request,
            CancellationToken cancellationToken
        )
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(
                predicate: uoc => uoc.Id == request.Id,
                cancellationToken: cancellationToken
            );
            await _userOperationClaimBusinessRules.UserOperationClaimShouldExistWhenSelected(userOperationClaim);

            await _userOperationClaimRepository.DeleteAsync(userOperationClaim!);

            DeletedUserOperationClaimResponse response = _mapper.Map<DeletedUserOperationClaimResponse>(userOperationClaim);
            return response;
        }
    }
}
