namespace Fimple.FinalCase.Core.Ports.Driving.Common;

public interface IAsyncService<TEntity>
{
    public Task<TEntity> CreateAsync(TEntity entity);
    public Task<int> DeleteAsync(int id);
    public Task<int> UpdateAsync(int id, TEntity entity);
    public Task<TEntity> GetByIdAsync(int id);
    public Task<List<TEntity>> GetAllAsync();
}