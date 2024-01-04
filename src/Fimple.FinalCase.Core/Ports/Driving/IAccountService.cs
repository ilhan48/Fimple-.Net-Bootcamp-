using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Ports.Driving.Common;

namespace Fimple.FinalCase.Core.Ports.Driving;

public interface IAccountService
{
    public Task<Account> CreateAsync(Account entity);
    public Task<decimal> UpdateBalanceAsync(int id, decimal amount);
    public Task<Account> GetByIdAsync(int id);
}