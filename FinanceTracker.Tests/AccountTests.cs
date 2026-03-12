using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using Xunit;

public class AccountTests
{
    [Fact]
    public void Applying_income_should_increase_balance()
    {
        var account = new Account(Guid.NewGuid(), "Conta Principal", AccountType.Bank, 1000);
        var transaction = new Transaction(
            Guid.NewGuid(),
            account.Id,
            Guid.NewGuid(),
            "Salário",
            2000,
            DateTime.Today,
            TransactionType.Income);

        account.ApplyTransaction(transaction);

        Assert.Equal(3000, account.Balance);
    }

    [Fact]
    public void Applying_expense_should_decrease_balance()
    {
        var account = new Account(Guid.NewGuid(), "Conta Principal", AccountType.Bank, 1000);
        var transaction = new Transaction(
            Guid.NewGuid(),
            account.Id,
            Guid.NewGuid(),
            "Aluguel",
            500,
            DateTime.Today,
            TransactionType.Expense);

        account.ApplyTransaction(transaction);

        Assert.Equal(500, account.Balance);
    }
}