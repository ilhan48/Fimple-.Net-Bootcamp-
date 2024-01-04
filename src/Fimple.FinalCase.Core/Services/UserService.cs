using System.Linq.Expressions;
using AutoMapper;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.Users.Commands.Create;
using Fimple.FinalCase.Core.Features.Users.Commands.Delete;
using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using Fimple.FinalCase.Core.Features.Users.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Hashing;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly UserBusinessRules _userBusinessRules;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, UserBusinessRules userBusinessRules, IMapper mapper)
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _mapper = mapper;
    }

    public async Task<ListUserDto?> GetAsync(
        Expression<Func<ListUserDto, bool>> predicate,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ListUserDto? user = await _userRepository.GetAsync(
        predicate,
        include,
        cancellationToken
    );
    return user;
    }

    public async Task<IPaginate<ListUserDto>?> GetListAsync(
        Expression<Func<ListUserDto, bool>>? predicate = null,
        Func<IQueryable<ListUserDto>, IOrderedQueryable<ListUserDto>>? orderBy = null,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ListUserDto> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            cancellationToken
        );
        return userList;
    }

    public async Task<CreatedUserResponse> AddAsync(CreateUserCommand createUserDto)
    {

        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(createUserDto.Email);

        CreateUserDto user = _mapper.Map<CreateUserDto>(createUserDto);
        HashingHelper.CreatePasswordHash(
            createUserDto.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        CreateUserDto addedUser = await _userRepository.AddAsync(user);
        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(addedUser);
        return response;
    }

    public async Task<CreatedUserResponse> UpdateAsync(int id, CreateUserCommand updateUser)
    {
        ListUserDto? getUser = await GetAsync(predicate: u => u.Id == id);
        var user = _mapper.Map<User>(getUser);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user!.Id, user.Email);
        user = _mapper.Map(updateUser, user);

        HashingHelper.CreatePasswordHash(
            updateUser.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user!.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var updatedUser = _mapper.Map<UpdateUserDto>(user);
        var response = await _userRepository.UpdateAsync(user.Id, updatedUser);
        return _mapper.Map<CreatedUserResponse>(response);
    }

    public async Task<DeletedUserResponse> DeleteAsync(int id, bool permanent = false)
    {
        ListUserDto? user = await GetAsync(predicate: u => u.Id == id);
        var response = _mapper.Map<User>(user);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(response);

        DeleteUserDto deletedUser = await _userRepository.DeleteAsync(id);

        return _mapper.Map<DeletedUserResponse>(deletedUser);
    }

    public async Task<UpdatedUserResponse> UpdateAsync(int id, UpdateUserCommand updateUser)
    {
        
        ListUserDto? getUser = await GetAsync(predicate: u => u.Id == id);
        var user = _mapper.Map<User>(getUser);
        await _userBusinessRules.UserShouldBeExistsWhenSelected(user);
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user!.Id, user.Email);
        user = _mapper.Map(updateUser, user);

        HashingHelper.CreatePasswordHash(
            updateUser.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );
        user!.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var updatedUser = _mapper.Map<UpdateUserDto>(user);
        var response = await _userRepository.UpdateAsync(user.Id, updatedUser);
        return _mapper.Map<UpdatedUserResponse>(response);
    }
}
