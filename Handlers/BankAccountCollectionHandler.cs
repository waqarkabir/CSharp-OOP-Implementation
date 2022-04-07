using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers
{
    public class BankAccountCollectionHandler
    {
        private readonly ArrayList _bankAccounts;
        public BankAccountCollectionHandler()
        {
            _bankAccounts = new ArrayList();
        }

        public void Add(BankAccount bankAccount)
        {
            _bankAccounts.Add(bankAccount);
        }

        public BankAccount? GetBankAccount(string Code, bool ignoreCase = false)
        {
            BankAccount? bankAccount = null;

            for (int i = 0; i < _bankAccounts.Count; i++)
            {
                BankAccount? account = _bankAccounts[i] as BankAccount;

                if (account != null)
                {
                    if (string.Compare(account.Code, Code, ignoreCase) == 0)
                    {
                        bankAccount = account;
                        break;
                    }
                }
            }

            return bankAccount;
        }

        public BankAccount[] GetBankAccounts()
        {
            return (BankAccount[])_bankAccounts.ToArray(typeof(BankAccount));
        }
    }
}
