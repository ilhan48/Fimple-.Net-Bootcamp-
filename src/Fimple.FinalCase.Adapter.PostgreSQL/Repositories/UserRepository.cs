using System.Linq.Expressions;
using AutoMapper;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.DTOs;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driven.Common;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class UserRepository : IUserRepository, IQuery<ListUserDto>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CreateUserDto> AddAsync(CreateUserDto createUserDto)
    {
        await _applicationDbContext.AddAsync(createUserDto);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return createUserDto;
    }

    public async Task<DeleteUserDto> DeleteAsync(int id)
    {
        var entity = _applicationDbContext.Users.FindAsync(id);
        _applicationDbContext.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        var response = _mapper.Map<DeleteUserDto>(entity);
        return response;
    }

    public async Task<ListUserDto?> UpdateAsync(int id, UpdateUserDto updateUserDto)
    {
        var updateUser = _mapper.Map<User>(updateUserDto);
        _applicationDbContext.Update(updateUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        var response = _mapper.Map<ListUserDto>(updateUserDto);
        return response;
    }

    public async Task<ListUserDto?> GetAsync(Expression<Func<ListUserDto, bool>> predicate, Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null, CancellationToken cancellationToken = default)
    {
        
        IQueryable<ListUserDto> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IPaginate<ListUserDto>> GetListAsync(Expression<Func<ListUserDto, bool>>? predicate = null, Func<IQueryable<ListUserDto>, IOrderedQueryable<ListUserDto>>? orderBy = null, Func<IQueryable<ListUserDto>, IIncludableQueryable<ListUserDto, object>>? include = null, int index = 0,
        int size = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<ListUserDto> queryable = Query();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, from: 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<ListUserDto, bool>>? predicate = null, CancellationToken cancellationToken = default)
    {
        IQueryable<ListUserDto> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        return await queryable.AnyAsync(cancellationToken);
    }

    public IQueryable<ListUserDto> Query()
    {
        return _applicationDbContext.Set<ListUserDto>();
    }
}
