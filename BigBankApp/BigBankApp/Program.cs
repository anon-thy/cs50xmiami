using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankData bank = new BankData();

            ShowMenu();

            while (true)
            {
                Console.WriteLine("");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "a":
                        Console.WriteLine("'Bank Funds' selected");
                        bank.Funds();
                        break;
                    case "b":
                        Console.WriteLine("'Create Account' selected");
                        Console.WriteLine("Enter name of account holder");
                        string accountHolder = Console.ReadLine();
                        bank.CreateAccount(accountHolder);
                        break;
                    case "c":
                        Console.WriteLine("'Account Deposit' selected");
                        bank.Deposit();
                        break;
                    case "d":
                        Console.WriteLine("'Account Withdrawl' selected");
                        bank.Withdraw();
                        break;
                    case "e":
                        Console.WriteLine("'Account Information' selected");
                        bank.Balance();
                        break;
                    case "f":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("a. Bank Funds");
            Console.WriteLine("b. Create Account");
            Console.WriteLine("c. Account Deposit");
            Console.WriteLine("d. Account Withdrawl");
            Console.WriteLine("e. Account Information");
            Console.WriteLine("f. Exit");
        }
    }
}
