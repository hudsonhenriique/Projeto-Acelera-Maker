using System;
using System.Linq;
using BankAccountSystem.Data;
using BankAccountSystem.Models;
using BankAccountSystem.Repositories;


namespace BankAccountSystem.Controllers
{
    public class AccountController: IAccountRepository
    {
        private readonly BankContext _context = new BankContext();

        public AccountController()
        {
            _context.Database.EnsureCreated();
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            Console.WriteLine($"Conta número {account.Number} criada com sucesso!");
        }

        public void ListAll()
        {
            var accounts = _context.Accounts.ToList();
            if (accounts.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada.");
                return;
            }

            foreach (var account in accounts)
            {
                string accountType = account is CheckingAccount ? "Conta Corrente" : "Conta Poupança";
                Console.WriteLine($"Número: {account.Number} | Tipo: {accountType} | Titular: {account.HolderName} | Saldo: {account.Balance:C}");
            }
        }
        public void FindByNumber(int number)
            {
            var account = _context.Accounts.FirstOrDefault(a => a.Number == number);
            string accountType = account is CheckingAccount ? "Conta Corrente" : "Conta Poupança";

            if (account != null)
                Console.WriteLine($"Conta encontrada: Número: {account.Number} | Tipo: {accountType} | Titular: {account.HolderName} | Saldo: {account.Balance:C}");
            else
                Console.WriteLine($"Conta número {number} não encontrada.");            
            }
        public void Update(Account account)
        {
            var existingAccount = _context.Accounts.FirstOrDefault(a => a.Number == account.Number);

            if (existingAccount != null)
            {
                existingAccount.HolderName = account.HolderName;
                existingAccount.Agency = account.Agency;
                existingAccount.Type = account.Type;

                _context.SaveChanges();
                Console.WriteLine($"Conta número {account.Number} atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine($"Conta número {account.Number} não encontrada. Atualização falhou.");
            }
        }

        public void Delete(int number)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Number == number);

            if(account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
                Console.WriteLine($"Conta {number} deletada com sucesso!");
            }
            else
            {
                Console.WriteLine($"Conta número {number} não encontrada.");
            }
        }

        public void Withdraw(int number, decimal amount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Number == number);

            if (account != null)
            {
                if (account.Withdraw(amount))
                {
                    _context.SaveChanges();
                    Console.WriteLine($"Saque de {amount:C} realizado com sucesso. Novo saldo: {account.Balance:C}");
                }
                else
                {
                    Console.WriteLine("Erro: Saldo ou limite insuficiente");
                }
            }
            else
            {
                Console.WriteLine($"Conta número {number} não encontrada.");
            }
            
        }

        public void Deposit(int number,decimal amount)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Number == number);

            if (account != null)
            {
                account.Deposit(amount);
                _context.SaveChanges();
                Console.WriteLine($"Depósito de {amount:C} realizado com sucesso. Novo saldo: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine($"Conta número {number} não encontrada.");
            }
        }

        public void Transfer(int originNumber,int destinationNumber, decimal amount)
        {
            var originAccount = _context.Accounts.FirstOrDefault(a => a.Number == originNumber);
            var destinationAccount = _context.Accounts.FirstOrDefault(a => a.Number == destinationNumber);

            if (originAccount == null)
            {
                Console.WriteLine($"Conta de origem {originNumber} não encontrada");
                return;
            }
            if (destinationAccount == null)
            {
                Console.WriteLine($"Conta de destino {destinationNumber} não encontrada");
                return;
            }
            if (originAccount.Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                _context.SaveChanges();
                Console.WriteLine($"Transferência de {amount:C} realizada com sucesso. Novo saldo da conta de origem: {originAccount.Balance:C}");
            }
            else
            {
                Console.WriteLine("Falha na transferência. Saldo insuficiente na conta de origem");
            }
        }
    }
}
