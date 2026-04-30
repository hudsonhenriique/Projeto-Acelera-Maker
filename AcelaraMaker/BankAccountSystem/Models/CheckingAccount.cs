using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.Models
{
   public class CheckingAccount: Account
    {
        public decimal Limit { get; set; }
        public CheckingAccount(int number,int agency,int type,string holderName, decimal balance,decimal limit) : base(number, agency, type, holderName, balance)
        {
            Limit = limit;
        }

        public override bool Withdraw(decimal amount)
        {
            if((Balance + Limit) >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
