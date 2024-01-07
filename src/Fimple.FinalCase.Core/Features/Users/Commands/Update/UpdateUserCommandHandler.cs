using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Hashing;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<UpdatedUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetAsync(predicate: u => u.Id == request.Id, cancellationToken: cancellationToken);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user!.Id, user.Email);
        user = _mapper.Map(request, user);

        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user!.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        await _userRepository.UpdateAsync(user);

        UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(user);
        return response;
    }
}
