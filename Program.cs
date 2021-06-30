using System;
using System.Collections.Generic;
using bank.Classes;
using bank.Classes.Enum;

namespace bank
{
    class Program
    {
        static List<Account> listAccount = new List<Account>();

        static void Main(string[] args)
        {
            string userOption = UserOptionCLI();
            
            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        GetAccounts();
                        break;
                    case "2":
                        RegisterAccount();
                        break;
                    case "3":
                        TransferMoney();
                        break;
                    case "4":
                        WithdrawMoney();
                        break;
                    case "5":
                        DepositMoney();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = UserOptionCLI();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços");
            Console.ReadLine();
        }

        private static void RegisterAccount()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.Write("Digit 1 para Conta Fisica ou 2 para Juridica: ");
            int inputAccountType = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do titula: ");
            string inputName = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double inputBalance = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito disponivel: ");
            double inputCredit = double.Parse(Console.ReadLine());

            /*
                Permite setar fora de ordem:
                new Account(accountType: (AccountType)inputAccountType,
                                            balance: inputBalance,
                                            credit: inputCredit,
                                            name: inputName);

                Pelo Contrario, não permite setar fora de ordem (tem que ser na ondem que foi determinado no construtor):
                new Account((AccountType)inputAccountType,
                                         inputBalance,
                                         inputCredit,
                                         inputName);
            */
            Account newAccount = new Account(accountType: (AccountType)inputAccountType,
                                            balance: inputBalance,
                                            credit: inputCredit,
                                            name: inputName);

            listAccount.Add(newAccount);
        }

        private static void GetAccounts()
        {
            Console.WriteLine("Listar contas");

            if (listAccount.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta cadastrada");
                return;
            }

            for (int i = 0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void WithdrawMoney()
        {
            Console.WriteLine("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            listAccount[accountIndex].Withdraw(withdrawValue);
        }

        private static void DepositMoney()
        {
            Console.WriteLine("Digite o número da conta: ");
            int accountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser deposito: ");
            double depositValue = double.Parse(Console.ReadLine());

            listAccount[accountIndex].Deposit(depositValue);
        }

        private static void TransferMoney()
        {
            Console.WriteLine("Digite o número da conta de origem: ");
            int originAccountIndex = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int traferToAccountIndex = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double transferValue = double.Parse(Console.ReadLine());

            listAccount[originAccountIndex].Transfer(transferValue, listAccount[traferToAccountIndex]);
        }

        private static string UserOptionCLI()
        {
            Console.WriteLine();
            Console.WriteLine("Liberty City Bank ao seu dispor");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1. Listar contas");
            Console.WriteLine("2. Inserir uma nova conta");
            Console.WriteLine("3. Realizar uma transferência");
            Console.WriteLine("4. Sacar de uma conta");
            Console.WriteLine("5. Depositar em uma conta");
            Console.WriteLine();
            Console.WriteLine("C - Limpar a Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return userOption;
        }
    }
}
