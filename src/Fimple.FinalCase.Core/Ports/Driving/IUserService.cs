using System.Linq.Expressions;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Features.Users.Commands.Create;
using Fimple.FinalCase.Core.Features.Users.Commands.Delete;
using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IUserService
{
    Task<ListUserDto?> GetAsync(
        Expression<Func<ListUserDto, bool>> predicate,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<ListUserDto>?> GetListAsync(
        Expression<Func<ListUserDto, bool>>? predicate = null,
        Func<IQueryable<ListUserDto>, IOrderedQueryable<ListUserDto>>? orderBy = null,
        Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<CreatedUserResponse> AddAsync(CreateUserCommand createUser);
    Task<UpdatedUserResponse> UpdateAsync(int id, UpdateUserCommand updateUser);
    Task<DeletedUserResponse> DeleteAsync(int id, bool permanent = false);
}