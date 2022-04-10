using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class AccountTransaction
    {
        public static void TransferAmountMessage(BankAccount? senderBankAccount,
               BankAccount? receiverBankAccount, decimal amount)
        {
            Console.WriteLine($"Amount of {amount} is transfered from Bank Account: {senderBankAccount.Code} to {receiverBankAccount.Code}");
            Console.WriteLine($"Your current balance is: {senderBankAccount.Balance}");
            Console.WriteLine("Press any key for main menu");
            Console.ReadKey();
        }
    }
}
