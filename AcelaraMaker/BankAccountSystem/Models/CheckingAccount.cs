using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccountSystem.Models
{
    // Conta corrente (CheckingAccount) herda de Account e adiciona um limite de cheque especial.
    // O limite permite que o cliente saque além do saldo até um valor adicional (Limit).
    public class CheckingAccount : Account
    {
        public decimal Limit { get; set; }
        public CheckingAccount(int number,int agency,int type,string holderName, decimal balance,decimal limit) : base(number, agency, type, holderName, balance)
        {
            Limit = limit;
        }

        // Se saldo + limite for suficiente para cobrir o saque, o valor é subtraído do saldo
        // (sem separar quanto veio do limite) e retorna true; caso contrário retorna false.
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
