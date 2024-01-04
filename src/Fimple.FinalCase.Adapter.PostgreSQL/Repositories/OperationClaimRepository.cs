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

public class OperationClaimRepository : IOperationClaimRepository, IQuery<OperationClaim>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public OperationClaimRepository(ApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IQueryable<OperationClaim> Query()=> _applicationDbContext.Set<OperationClaim>();

    public async Task<OperationClaim?> GetAsync(Expression<Func<OperationClaim, bool>> predicate, Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>>? include = null, bool withDeleted = false, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<OperationClaim> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IPaginate<OperationClaim>> GetListAsync(Expression<Func<OperationClaim, bool>>? predicate = null, Func<IQueryable<OperationClaim>, IOrderedQueryable<OperationClaim>>? orderBy = null, Func<IQueryable<OperationClaim>, IIncludableQueryable<OperationClaim, object>>? include = null, int index = 0,
        int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<OperationClaim> queryable = Query();
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

    public async Task<bool> AnyAsync(Expression<Func<OperationClaim, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<OperationClaim> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        return await queryable.AnyAsync(cancellationToken);
    }

    public async Task<OperationClaim> AddAsync(OperationClaim entity)
    {
        await _applicationDbContext.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<OperationClaim> UpdateAsync(OperationClaim entity)
    {
        _applicationDbContext.Update(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        return entity;
    }

    public async Task<OperationClaim> DeleteAsync(OperationClaim entity, bool permanent = false)
    {
        _applicationDbContext.Remove(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        var response = _mapper.Map<OperationClaim>(entity);
        return response;
    }

    IQueryable<OperationClaim> IQuery<OperationClaim>.Query()
    {
        throw new NotImplementedException();
    }
}
