using System;
using Xunit;
using BankAccountSystem;
using BankAccountSystem.Models;

namespace BankAccountSystem.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Withdraw_ShouldDecreaseBalance_WhenSufficientFunds()
        {
            decimal initialBalance = 500m;
            decimal limit = 100m;
            decimal withdrawAmount = 200m;
            decimal expectedBalance = initialBalance - withdrawAmount;

            CheckingAccount account = new CheckingAccount(1,123,1,"Souza",initialBalance,limit);

            bool success = account.Withdraw(withdrawAmount);

            Assert.True(success);
            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]

        public void Withdraw_ShouldFail_WhenAmountExceedsBalanceAndLimit()
        {
            decimal initialBalance = 500m;
            decimal limit = 100m;
            decimal withdrawAmount = 700m;

            CheckingAccount account = new CheckingAccount(1,123,1,"Souza",initialBalance,limit);

            bool success = account.Withdraw(withdrawAmount);

            Assert.False(success);
            Assert.Equal(initialBalance, account.Balance);
        }
    }
}
