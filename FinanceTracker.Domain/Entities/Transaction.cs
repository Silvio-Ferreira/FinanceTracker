using FinanceTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid CategoryId { get; private set; }

    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }

    public TransactionType Type { get; private set; }

    protected Transaction() { }

    public Transaction(
        Guid userId,
        Guid accountId,
        Guid categoryId,
        string description,
        decimal amount,
        DateTime date,
        TransactionType type)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Id = Guid.NewGuid();
        UserId = userId;
        AccountId = accountId;
        CategoryId = categoryId;
        Description = description;
        Amount = amount;
        Date = date;
        Type = type;
    }
}