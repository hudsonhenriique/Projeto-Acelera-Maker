using System;
using System.Runtime.CompilerServices;
using BankAccountSystem.Controllers;
using BankAccountSystem.Models;
using BankAccountSystem.Utils;

namespace BankAccountSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountController controller = new AccountController();
            int option = 0;

            while (true)
            {
                Console.Clear();
                ConsoleColors.ShowHeader("========================================");
                ConsoleColors.ShowHeader("          SISTEMA BANCÁRIO MAKER        ");
                ConsoleColors.ShowHeader("========================================");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Listar Contas");
                Console.WriteLine("3 - Buscar Conta por Número");
                Console.WriteLine("4 - Atualizar dados da Conta");
                Console.WriteLine("5 - Apagar Conta");
                Console.WriteLine("6 - Sacar");
                Console.WriteLine("7 - Depositar");
                Console.WriteLine("8 - Transferir Valores");
                Console.WriteLine("9 - Sair");
                ConsoleColors.ShowHeader("========================================");
                ConsoleColors.ShowMenuText("Escolha uma opção: ");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    ConsoleColors.ShowError("Opção inválida! Por favor, digite apenas números.");
                    ConsoleColors.ShowMenuText("\nPressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }

                if(option == 9)
                {
                    ConsoleColors.ShowSuccess("Obrigado por usar o Sistema Bancário Maker! Até a próxima!");
                    break;
                }

                try
                {
                    switch(option)
                    {
                        case 1:
                            ConsoleColors.ShowHeader("\n--- Criar Conta ---");
                            Console.Write("Digite o número da conta: ");
                            int number = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite a Agência: ");
                            int agency = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite o Tipo da Conta (1 - Corrente, 2 - Poupança): ");
                            int type = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Digite o nome do titular: ");
                            string? holder = Console.ReadLine();

                            Console.Write("Digite o Saldo Inicial: ");
                            decimal balance = Convert.ToDecimal(Console.ReadLine());

                            if(type ==1)
                            {
                                Console.Write("Digite o limite da Conta Corrente: ");
                                decimal limit = Convert.ToDecimal(Console.ReadLine());

                                CheckingAccount cc = new CheckingAccount(number,agency, type, holder ?? "", balance, limit);
                                controller.Create(cc);
                            }
                            else if(type ==2)
                            {
                                Console.Write("Digite apenas o DIA do aniversário da Conta Poupança NÂO a DATA  (ex: 1 a 31):  ");
                                int anniversaryDay = Convert.ToInt32(Console.ReadLine());

                                SavingsAccount cp = new SavingsAccount(number, agency, type, holder ?? "", balance, anniversaryDay);
                                controller.Create(cp);
                            }
                            else
                            {
                                ConsoleColors.ShowError("Tipo de conta inválido! Por favor, escolha 1 para Corrente ou 2 para Poupança.");
                            }
                            break;
                        case 2:
                            ConsoleColors.ShowHeader("\n--- Listar Contas ---");
                            controller.ListAll();
                            break;

                        case 3:
                            ConsoleColors.ShowHeader("\n--- Buscar conta por número ---");
                            Console.Write("Digite o número da conta: ");
                            int searchNumber = Convert.ToInt32(Console.ReadLine());
                            controller.FindByNumber(searchNumber);
                            break;

                        case 4:
                            ConsoleColors.ShowHeader("\n--- Atualizar dados da conta ---");
                            Console.Write("Digite o núemro da conta que deseja atualizar: ");
                            int upNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite a nova Agência: ");
                            int upAgency = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o novo tipo da conta (1 - Corrente, 2 - Poupança): ");
                            int upType = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o novo nome do titular: ");
                            string? upHolder = Console.ReadLine();

                            Account updateAcc = new SavingsAccount(upNumber, upAgency, upType, upHolder ?? "", 0, 0);
                            controller.Update(updateAcc);
                            break;

                        case 5:
                            ConsoleColors.ShowHeader("\n--- Apagar conta ---");
                            Console.Write("Digite o número da conta a ser apagada: ");
                            int delNumber = Convert.ToInt32(Console.ReadLine());
                            controller.Delete(delNumber);
                            break;

                        case 6:
                            ConsoleColors.ShowHeader("\n--- Sacar ---");
                            Console.Write("Digite o número da conta: ");
                            int withNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor do saque: ");
                            decimal withAmount = Convert.ToDecimal(Console.ReadLine());
                            controller.Withdraw(withNumber, withAmount);
                            break;

                        case 7:
                            ConsoleColors.ShowHeader("\n--- Depositar ---");
                            Console.Write("Digite o número da conta: ");
                            int depNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor do depósito: ");
                            decimal depAmount = Convert.ToDecimal(Console.ReadLine());
                            controller.Deposit(depNumber, depAmount);
                            break;

                        case 8:
                            ConsoleColors.ShowHeader("\n--- Transferir Valores ---");
                            Console.Write("Digite o número da conta de ORIGEM: ");
                            int fromNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o número da conta de DESTINO: ");
                            int toNumber = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Digite o valor a ser transferido: ");
                            decimal transAmount = Convert.ToDecimal(Console.ReadLine());
                            controller.Transfer(fromNumber, toNumber, transAmount);
                            break;

                        default:
                            ConsoleColors.ShowError("Opção inválida! Por favor, escolha uma opção entre 1 e 9.");
                            break;
                    }
                }
                catch(Exception ex)
                {
                    ConsoleColors.ShowError($"\nErro: inesperado do sistema: {ex.Message}");
                }

                ConsoleColors.ShowMenuText("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}