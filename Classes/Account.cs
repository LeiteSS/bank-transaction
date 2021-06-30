using System;
using bank.Classes.Enum;

namespace bank.Classes
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double withdrawValue)
        {
            if (this.Balance - withdrawValue < (this.Credit *-1))
            {
                Console.WriteLine("Insufficient Funds");
                
                return false;
            }

            this.Balance -= withdrawValue;

            Console.WriteLine("Dear {0}, your Current Balance of the account is {1}", this.Name, this.Balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;

            Console.WriteLine("Dear {0}, your Current Balance of the account is {1}", this.Name, this.Balance);
        }

        public void Transfer(double transferValue, Account accountToTransfer)
        {
            if (this.Withdraw(transferValue))
            {
                accountToTransfer.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            string output = "";

            output += "Tipo da conta: " + this.AccountType + " | ";
            output += "Nome do titular da conta: " + this.Name + " | ";
            output += "Saldo da conta: " + this.Balance + " | ";
            output += "Crédito em conta: " + this.Credit;

            return output;
        }
    }
}