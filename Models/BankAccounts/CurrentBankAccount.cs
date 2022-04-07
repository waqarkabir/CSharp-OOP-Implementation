using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount(decimal openingBalance = 1000) 
            : base(AccountType.Current, openingBalance)
        {
        }

        public override bool WithDraw(decimal amount)
        {
            //TODO: Add your code here

            amount = amount - 50;

            return base.WithDraw(amount);
        }
    }
}
