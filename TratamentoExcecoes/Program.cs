using System;
using System.Numerics;
using System.Globalization;
using TratamentoExcecoes.Entities;
using System.Security.Principal;

namespace TratamentoExcecoes
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter account data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string holder = Console.ReadLine();

            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Withdraw limit: ");
            double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account account = new Account(number, holder, balance, withdrawLimit);

            Console.WriteLine("");

            try
            {
                Console.Write("Do you want to deposit or withdraw?: d(to deposit) or w(to withdraw) ");
                string operation = Console.ReadLine();

                if (operation == "w")
                {
                    Console.Write("Enter amount for withdraw: ");
                    double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    account.Withdraw(withdraw);
                }
                else if(operation == "d")
                {
                    Console.Write("Enter amount for deposit: ");
                    double deposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    account.Deposit(deposit);
                }
                else
                {
                    Console.WriteLine("Operation invalid");
                }

                Console.WriteLine("");

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

}