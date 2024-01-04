using System.Linq.Expressions;
using AutoMapper;
using Fimple.FinalCase.Adapter.PostgreSQL.Contexts;
using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driven.Common;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Fimple.FinalCase.Adapter.PostgreSQL.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository, IQuery<RefreshToken>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RefreshTokenRepository(ApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IQueryable<RefreshToken> Query()=> _applicationDbContext.Set<RefreshToken>();

    public async Task<RefreshToken?> GetAsync(Expression<Func<RefreshToken, bool>> predicate, Func<IQueryable<RefreshToken>, IIncludableQueryable<RefreshToken, object>>? include = null, bool withDeleted = false, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<RefreshToken> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IPaginate<RefreshToken>> GetListAsync(Expression<Func<RefreshToken, bool>>? predicate = null, Func<IQueryable<RefreshToken>, IOrderedQueryable<RefreshToken>>? orderBy = null, Func<IQueryable<RefreshToken>, IIncludableQueryable<RefreshToken, object>>? include = null, int index = 0,
        int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<RefreshToken> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, from: 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<RefreshToken, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<RefreshToken> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<RefreshToken> AddAsync(RefreshToken entity)
    {
        await _applicationDbContext.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<RefreshToken> UpdateAsync(RefreshToken entity)
    {
        _applicationDbContext.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<ICollection<RefreshToken>> DeleteRangeAsync(ICollection<RefreshToken> entity, bool permanent = false)
    {
        _applicationDbContext.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

}
