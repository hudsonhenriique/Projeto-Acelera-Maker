using System;
using System.Collections.Generic;
using System.Text;
using BankAccountSystem;

using BankAccountSystem.Models;

namespace BankAccountSystem.Repositories
{
    public interface IAccountRepository
    {
        void FindByNumber(int number);
        void ListAll();
        void Create(Account account);
        void Update(Account account);
        void Delete(int number);
        void Withdraw(int number, decimal amount);
        void Deposit(int number, decimal amount);
        void Transfer(int originNumber, int destinationNumber, decimal amount);
    }
}
