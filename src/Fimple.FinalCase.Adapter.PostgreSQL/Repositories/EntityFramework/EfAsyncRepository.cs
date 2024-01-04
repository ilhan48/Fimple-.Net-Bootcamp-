using System.Linq.Expressions;
using Fimple.FinalCase.Adapter.PostgreSQL;
using Fimple.FinalCase.Core.Entities.Common;
using Fimple.FinalCase.Core.Ports.Driven.Common;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Repositories.EntityFramework;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
    where TEntity : BaseAuditableEntity<int>
    where TContext : DbContext
{
    protected readonly TContext Context;
    private readonly IUnitOfWork _unitOfWork;

    public EfRepositoryBase(TContext context, IUnitOfWork unitOfWork )
    {
        Context = context;
        _unitOfWork = unitOfWork;
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await Context.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<IPaginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> queryable = Query();
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

    public async Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        return await queryable.AnyAsync(cancellationToken);
    }
}