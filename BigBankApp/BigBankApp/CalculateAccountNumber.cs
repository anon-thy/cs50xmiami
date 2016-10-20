using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBankApp
{
    class CalculateAccountNumber
    {
        static Random generator = new Random();
        string accountNumber = generator.Next(100, 999).ToString();

        public string IBAN()
        {
            return accountNumber;
        }
    }
}
