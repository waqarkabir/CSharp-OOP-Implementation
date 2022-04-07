using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SavingBankAccount : BankAccount, ITransferBankAccount
    {
        public static new int Total = 0;
        public SavingBankAccount(decimal openingBalance = 500)
            : base(AccountType.Saving, openingBalance)
        {
            Total = Total + 1;
        }


        // a.Transfer(b, 1000);


        public bool Transfer(BankAccount bankAccount, decimal amount)
        {
            //TODO:How many Bank account objects ???
            SavingBankAccount? temp = bankAccount as SavingBankAccount;

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

        public override bool WithDraw(decimal amount)
        {
            //TODO: Add your code here
            decimal tax = 0;
            if (amount > 50000)
            {
                tax = 0.06M * amount;
            }

            amount = amount - tax;

            return base.WithDraw(amount);
        }
    }
}
