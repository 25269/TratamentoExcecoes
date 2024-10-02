using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Globalization;

namespace TratamentoExcecoes.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() { }
        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit (double amount) 
        {
            if(amount >= 0)
            {
                Balance += amount;
                Console.Write("New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture));
                return;
            }
            else
            {
                throw new Exception("Deposit error: Invalid value");
            }
        }

        public void Withdraw(double amount)
        {
            if(amount < WithdrawLimit && amount >= 0 && amount < Balance)
            {
                Balance -= amount;
                Console.Write("New balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture));
                return;
            }
            else if(amount > Balance)
            {
                throw new Exception("Withdraw error: not enough balance");
            }
            else if (amount < 0)
            {
                throw new Exception("Withdraw error: negative withdraw");
            }
            else
            {
                throw new Exception("Withdraw error: The amount exceeds withdraw limit");
            }

        }

    }
}
