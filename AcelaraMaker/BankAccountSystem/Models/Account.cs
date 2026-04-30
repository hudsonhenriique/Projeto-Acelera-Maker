using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.Models
{
    public abstract class  Account
    {
        public int Number { get; set; }
        public int Agency { get; set; }
        public int Type { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }

        public Account(int number,int agency, int type, string holderName, decimal balance)
        {
            Number = number;
            Agency = agency;
            Type = type;
            HolderName = holderName;
            Balance = balance;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
