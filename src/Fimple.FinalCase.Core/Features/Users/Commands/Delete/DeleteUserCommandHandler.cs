using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using MediatR;
namespace Fimple.FinalCase.Core.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

        await _userRepository.DeleteAsync(user!);

        DeletedUserResponse response = _mapper.Map<DeletedUserResponse>(user);
        return response;
    }
}
