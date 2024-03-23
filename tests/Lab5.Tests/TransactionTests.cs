using System.Threading.Tasks;
using Core.Exceptions;
using Core.Models.Accounts;
using Core.Repositories;
using Core.Services;
using Core.Services.AccountServices;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionTests
{
    [Fact]
    public void CorrectWithdrawMoney()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        long accountId = 1;
        long userId = 1;
        long accountBalance = 310;
        accountRepository.GetAccountById(accountId).Returns(new Account(accountId, accountBalance, userId));
        long amountOfMoney = 100;
        ICommandResult<long> command = new WithdrawAccountMoney(accountRepository, amountOfMoney, accountId);

        // Act
        Task<long> result = command.Execute();

        // Assert
        Assert.Equal(accountBalance - amountOfMoney, result.Result);
    }

    [Fact]
    public async Task IncorrectWithdrawMoney()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        long accountId = 1;
        long userId = 1;
        long accountBalance = 90;
        accountRepository.GetAccountById(accountId).Returns(new Account(accountId, accountBalance, userId));
        long amountOfMoney = 100;
        ICommandResult<long> command = new WithdrawAccountMoney(accountRepository, amountOfMoney, accountId);

        // Act, Assert
        await Assert.ThrowsAsync<NegativeBalanceException>(() => command.Execute()).ConfigureAwait(false);
    }

    [Fact]
    public void AddAccountMoney()
    {
        // Arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        long accountId = 1;
        long userId = 1;
        long accountBalance = 310;
        accountRepository.GetAccountById(accountId).Returns(new Account(accountId, accountBalance, userId));
        long amountOfMoney = 100;
        ICommandResult<long> command = new AddAccountMoney(accountRepository, amountOfMoney, accountId);

        // Act
        Task<long> result = command.Execute();

        // Assert
        Assert.Equal(accountBalance + amountOfMoney, result.Result);
    }
}