using System;
using System.Collections.Generic;
using System.Text;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.UseCases.Accounts;

public class CreateAccountUseCase
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Account> ExecuteAsync(
        Guid userId,
        string name,
        AccountType type,
        decimal initialBalance)
    {
        var account = new Account(
            userId: userId,
            name: name,
            type: type,
            initialBalance: initialBalance
        );

        return await _accountRepository.AddAsync(account);
    }
}