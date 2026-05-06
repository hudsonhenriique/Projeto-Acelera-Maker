using System;
using System.Collections.Generic;
using System.Text;
using BankAccountSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccountSystem.Data
{
    // DbContext classe principal do EF Core manda nas operações do banco de dados.
    
    public class BankContext: DbContext
    {
        // DbSet representa uma tabela no banco de dados.
        // O EF Core usará essa propriedade para consultar e salvar instâncias de Account.
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bank.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasDiscriminator<string>("AccountType")
                .HasValue<CheckingAccount>("Checking")
                .HasValue<SavingsAccount>("Savings");
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Number);
        }
    }
}
