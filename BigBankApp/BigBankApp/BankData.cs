using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBankApp
{
    class BankData : AccountData
    {
        ReturnedVal rv = new ReturnedVal();
        List<BankAccount> _accounts;

        public BankData()
        {
            _accounts = new List<BankAccount>();
        }

        public List<BankAccount> Account
        {
            get { return _accounts; }
        }
        
        public void Funds()
        {
            float totalFunds = 0;

            foreach (BankAccount account in _accounts)
            {
                totalFunds += account.Sum;
            }

            Console.WriteLine("Bank funds equal " + totalFunds + " dollars");
        }

        public void CreateAccount(string name)
        {
            BankAccount account = new BankAccount();
            CalculateAccountNumber calculateIban = new CalculateAccountNumber();

           
            Console.WriteLine("Enter 1 to create Checking Account");
            Console.WriteLine("Enter 2 to create Savings Account");

            int accountType = Convert.ToInt32(Console.ReadLine());

           // if (accountType != 1 || accountType != 2)
           // {
           //     Console.WriteLine("Selection invalid, please try again");
           //     accountType = Convert.ToInt32(Console.ReadLine());
           // }


            switch (accountType)
            {
                case 1:
                    account.Type = "checking";
                    break;
                case 2:
                    account.Type = "saving";
                    break;
            }

            if (account.Type == "checking")
            {
                account.Interest = 0.0M;
            }
            else if (account.Type == "saving")
            {
                account.Interest = 1.5M;
            }

            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    account.Name = name;
                    account.IBAN = calculateIban.IBAN();
                    _accounts.Add(account);
                    Console.WriteLine("Account created - Name: {0}, IBAN: {1}", account.Name, account.IBAN);
                }
                else
                {
                    Console.WriteLine("Account name is null or empty.");
                }
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne.StackTrace);
            }
        }

        public float Deposit()
        {
            string iban = rv.EnterIban();
            BankAccount account = rv.GetAccountByName(iban, _accounts);

            while (account == null)
            {
                Console.WriteLine("Account doesn't exist");
                iban = rv.EnterIban();
                account = rv.GetAccountByName(iban, _accounts);
            }

            float sum = rv.AmountToDeposit();
            while (sum <= 0)
            {
                Console.WriteLine("Amount cannot be less or equal than 0.");
                sum = 0;
                sum = rv.AmountToDeposit();
            }

            account.Sum += sum;
            Console.WriteLine("Added {0} to account {1}", sum, iban);

            return account.Sum;
        }

        public float Withdraw()
        {
            BankData details = new BankData();

            string iban = rv.EnterIban();
            BankAccount account = rv.GetAccountByName(iban, _accounts);

            while (account == null)
            {
                Console.WriteLine("Account doesn't exist");
                iban = rv.EnterIban();
                account = rv.GetAccountByName(iban, _accounts);
            }

            float sum = rv.AmountToDeposit();
            while (sum <= 0)
            {
                Console.WriteLine("Amount cannot be less or equal than 0.");
                sum = 0;
                sum = rv.AmountToDeposit();
            }

            account.Sum -= sum;

            Console.Write("Withdrawn {0} from account {1}.", sum, iban);
            account.Sum -= account.Sum;
            Console.WriteLine("Remaining: {0}", Math.Round(account.Sum, 2));

            return account.Sum;
        }

        public float Balance()
        {
            string iban = rv.EnterIban();
            BankAccount account = rv.GetAccountByName(iban, _accounts);

            Console.WriteLine("IBAN: {0} has {1} left with {2}% interest rate", iban, account.Sum, account.Interest);

            return account.Sum;
        }

    }
}
