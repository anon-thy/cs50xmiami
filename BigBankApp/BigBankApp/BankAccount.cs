using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBankApp
{
    class BankAccount
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string IBAN { get; set; }
        public float Sum { get; set; }
        public decimal Interest { get; set; }
    }
}
