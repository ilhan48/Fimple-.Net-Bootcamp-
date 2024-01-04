using AutoMapper;
using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Accounts.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;

namespace Fimple.FinalCase.Core.Services;

public class AccountService : IAccountService
{
    const decimal minimumBalance = 1000;
    private readonly IAccountRepository _accountRepository;

    private readonly AccountBusinessRules _accountBusinessRules;

    public AccountService(IAccountRepository accountRepository, AccountBusinessRules accountBusinessRules)
    {
        _accountRepository = accountRepository;
        _accountBusinessRules = accountBusinessRules;
    }
    public async Task<Account> CreateAsync(Account entity)
    {
        await _accountBusinessRules.AccountIdShouldExistWhenSelected(entity.Id, cancellationToken: default);
        await _accountBusinessRules.CheckMinimumBalance(entity, minimumBalance);

        Account addedUser = await _accountRepository.AddAsync(entity);
        return addedUser;
    }

    public async Task<decimal> UpdateBalanceAsync(int id, decimal newBalance)
    {
        Account account = await _accountRepository.GetAsync(a => a.Id == id);
        await _accountBusinessRules.AccountShouldExistWhenSelected(account);
        
        await _accountBusinessRules.CheckNegativeBalance(account);
        account.Balance = newBalance;
        await _accountRepository.UpdateAsync(account);
        return newBalance;
    }

    public async Task<Account> GetByIdAsync(int id)
    {
        Account? account = await _accountRepository.GetAsync(a=>a.Id == id);
        return account;
    }
}