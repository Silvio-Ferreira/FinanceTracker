using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public string Name { get; private set; }
    public AccountType Type { get; private set; }

    public decimal Balance { get; private set; }

    protected Account() { }

    public Account(Guid userId, string name, AccountType type, decimal initialBalance)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Type = type;
        Balance = initialBalance;
    }

    public void ApplyTransaction(Transaction transaction)
    {
        if (transaction.Type == TransactionType.Income)
            Balance += transaction.Amount;
        else
            Balance -= transaction.Amount;
    }

    public void RevertTransaction(Transaction transaction)
    {
        if (transaction.Type == TransactionType.Income)
            Balance -= transaction.Amount;
        else
            Balance += transaction.Amount;
    }
}
