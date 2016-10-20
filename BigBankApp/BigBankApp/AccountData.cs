using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBankApp
{
    interface AccountData
    {
        float Balance();
        void CreateAccount(string name);
        float Deposit();
        float Withdraw();
    }
}
