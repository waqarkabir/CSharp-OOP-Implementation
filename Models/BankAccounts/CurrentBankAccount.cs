using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CurrentBankAccount : BankAccount, ITransferBankAccount
    {
        public static new int Total = 0;
        public CurrentBankAccount(decimal openingBalance = 1000) 
            : base(AccountType.Current, openingBalance)
        {
            Total = Total + 1;
        }

        public override bool WithDraw(decimal amount)
        {
            //TODO: Add your code here

            amount = amount - 50;

            return base.WithDraw(amount);
        }

        public bool Transfer(BankAccount bankAccount, decimal amount)
        {
            //TODO:How many Bank account objects ???
            CurrentBankAccount? temp = bankAccount as CurrentBankAccount;

            if (temp == null)
            {
                return false;
            }

            if (!WithDraw(amount))
            {
                return false;
            }

            if (!bankAccount.PayIn(amount))
            {
                return PayIn(amount);
            }

            return true;
        }
    }
}
