using Models;

namespace Handlers
{
    public class BankAccountHandler
    {
        private readonly BankAccount[] bankAccounts;
        private int index = 0;
        public BankAccountHandler(int size)
        {
            bankAccounts = new BankAccount[size];
        }

        // Create
        public void Add(BankAccount bankAccount)
        {
            bankAccounts[index] = bankAccount;
            index += 1;
        }

        // Search
        public BankAccount? GetBankAccount(string Code, bool ignoreCase = false)
        {
            BankAccount? bankAccount = null;

            for (int i = 0; i < index; i++)
            {
                if (string.Compare(bankAccounts[i].Code, Code, ignoreCase) == 0)
                {
                    bankAccount = bankAccounts[i];
                    break;
                }
            }

            return bankAccount;
        }

        // Return List
        public BankAccount[] GetBankAccounts()
        {
            return bankAccounts;
        }

    }
}