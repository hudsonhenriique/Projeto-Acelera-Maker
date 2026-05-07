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

            CheckingAccount account = new CheckingAccount(1,123,1,"Maria",initialBalance,limit);

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

            CheckingAccount account = new CheckingAccount(2,456,1,"Souza",initialBalance,limit);

            bool success = account.Withdraw(withdrawAmount);

            Assert.False(success);
            Assert.Equal(initialBalance, account.Balance);
        }

        [Fact]

        public void CreateSavingsAccount_ShouldSucceed_WhenAnniversaryDayIsValid()
        {
            int validDay = 15;

            SavingsAccount account = new SavingsAccount(1,123,2,"José",1000m,validDay);

            Assert.NotNull(account);
            Assert.Equal(validDay, account.AnniversaryDay);
        }

        [Fact]

        public void CreateSavingsAccount_ShouldThrowException_WhenAnniversaryDayIsInvalid()
        {
            int invalidDAy = 50;

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            new SavingsAccount(4, 123, 2, "João", 1000m, invalidDAy)
            );
            Assert.Equal("O dia do aniversário deve estar entre 1 e 31.", exception.Message);
        }

        [Fact]

        public void Deposit_ShouldIncreaseBalance_WhenAmountIsAdded()
        {
            decimal initialBalance = 300m;
            decimal depositAmount = 150m;
            decimal expectedBalance = initialBalance + depositAmount;

            CheckingAccount account = new CheckingAccount(3,789,1,"Ana",initialBalance,50m);

            account.Deposit(depositAmount);

            Assert.Equal(expectedBalance, account.Balance);
        }

        [Fact]

        public void Transfer_ShouldMoveMoney_WhenOriginHasSufficientFunds()
        {
            CheckingAccount originAccount = new CheckingAccount(1,123,1,"Maria",500m,100m);
            SavingsAccount destinationAccount = new SavingsAccount(2,456,2,"Henrique",300m,10);

            decimal transferAmount = 200m;

            bool withdrawSuccess = originAccount.Withdraw(transferAmount);
            if (withdrawSuccess)
            {
                destinationAccount.Deposit(transferAmount);
            }

            Assert.True(withdrawSuccess);
            Assert.Equal(300m, originAccount.Balance);
            Assert.Equal(500m, destinationAccount.Balance);
        }

        [Fact]

        public void Transfer_ShouldFailAndNotMOveMoney_WhenOriginHasInsufficientFunds()
        {
            CheckingAccount originAccount = new CheckingAccount(1,123,1,"Maria",500m,100m);
            SavingsAccount destinationAccount = new SavingsAccount(2,456,2,"Henrique",300m,10);

            decimal transferAmount = 700m;

            bool withdrawSuccess = originAccount.Withdraw(transferAmount);
            if (withdrawSuccess)
            {
                destinationAccount.Deposit(transferAmount);
            }

            Assert.False(withdrawSuccess);
            Assert.Equal(500m, originAccount.Balance);
            Assert.Equal(300m, destinationAccount.Balance);
        }
    }
}
