using Fimple.FinalCase.Core.Entities;
using Fimple.FinalCase.Core.Features.Accounts.Constants;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Utilities.Exceptions.Types;

namespace Fimple.FinalCase.Core.Features.Accounts.Rules;

public class AccountBusinessRules
{
    private readonly IAccountRepository _accountRepository;

    public AccountBusinessRules(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public Task AccountShouldExistWhenSelected(Account? account)
    {
        if (account == null)
            throw new BusinessException(AccountsBusinessMessages.AccountNotExists);
        return Task.CompletedTask;
    }

    public async Task AccountIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Account? account = await _accountRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AccountShouldExistWhenSelected(account);
    }
    
    public Task CheckMinimumBalance(Account account, decimal minimumBalance)
    {
        if (account.Balance < minimumBalance)
        {
            throw new BusinessException(AccountsBusinessMessages.MinimumBalanceNotReached);
        }
        return Task.CompletedTask;
    }
    
    public Task CheckNegativeBalance(Account account)
    {
        if (account.Balance < 0)
        {
            throw new BusinessException(AccountsBusinessMessages.NegativeBalanceNotAllowed);
        }
        return Task.CompletedTask;
    }
}