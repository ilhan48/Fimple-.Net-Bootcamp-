using AutoMapper;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Hashing;
using MediatR;

namespace Fimple.FinalCase.Core.Features.Users.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(request.Email);
        User user = _mapper.Map<User>(request);

        HashingHelper.CreatePasswordHash(
            request.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        User createdUser = await _userRepository.AddAsync(user);

        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);
        return response;
    }
}
