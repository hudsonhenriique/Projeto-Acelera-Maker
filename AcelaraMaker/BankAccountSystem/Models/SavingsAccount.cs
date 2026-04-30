using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.Models
{
    public class SavingsAccount:Account
    {
        public int AnniversaryDay { get; set; }
        public SavingsAccount(int number,int agency,int type,string holderName,decimal balance,int anniversaryDay) : base(number, agency, type, holderName, balance)
        {
            AnniversaryDay = anniversaryDay;
        }
    }
}
