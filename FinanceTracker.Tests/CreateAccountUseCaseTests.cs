using System;
using System.Collections.Generic;
using System.Text;
using FinanceTracker.Application.Interfaces;
using FinanceTracker.Application.UseCases.Accounts;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using Moq;
using Xunit;

namespace FinanceTracker.Tests.UseCases.Accounts;

public class CreateAccountUseCaseTests
{
    [Fact]
    public async Task Should_Create_Account_Successfully()
    {
        // Arrange
        var repositoryMock = new Mock<IAccountRepository>();

        repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Account>()))
            .ReturnsAsync((Account account) => account);

        var useCase = new CreateAccountUseCase(repositoryMock.Object);

        var userId = Guid.NewGuid();

        // Act
        var account = await useCase.ExecuteAsync(
            userId,
            "Main Account",
            AccountType.Bank,
            1000m
        );

        // Assert
        Assert.NotNull(account);
        Assert.Equal(userId, account.UserId);
        Assert.Equal("Main Account", account.Name);
        Assert.Equal(AccountType.Bank, account.Type);
        Assert.Equal(1000m, account.Balance);
    }
}