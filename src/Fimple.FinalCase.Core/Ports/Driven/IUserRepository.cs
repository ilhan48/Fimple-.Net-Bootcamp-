using System.Linq.Expressions;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Ports.Driven;

public interface IUserRepository
{
    Task<CreateUserDto> AddAsync(CreateUserDto createUserDto);
    Task<DeleteUserDto> DeleteAsync(int id);
    Task<ListUserDto?> UpdateAsync(int id, UpdateUserDto updateUserDto);
    Task<ListUserDto?> GetAsync(
        Expression<Func<ListUserDto, bool>> predicate,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<ListUserDto>> GetListAsync(
        Expression<Func<ListUserDto, bool>>? predicate = null,
        Func<IQueryable<ListUserDto>, IOrderedQueryable<ListUserDto>>? orderBy = null,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<bool> AnyAsync(
        Expression<Func<User, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
}