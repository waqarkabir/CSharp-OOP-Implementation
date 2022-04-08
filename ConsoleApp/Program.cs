// See https://aka.ms/new-console-template for more information
using Handlers;
using Models;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BankAccountHandler bankAccountHandler = new BankAccountHandler(100);

            IBankAccountHandler bankAccountHandler = new BankAccountCollectionHandler();
            //IBankAccountHandler bankAccountHandler = new BankAccountHandler(100);
            bool choice = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. Search an existing account");
                Console.WriteLine("3. Show all accounts");
                Console.WriteLine("4. PayIn amount in account ");
                Console.WriteLine("5. Withdraw amount from account");
                Console.WriteLine("6. Transfer amount");

                string option = Console.ReadLine();
                string title, accountType, code, amount;
                BankAccount bankAccount = null;

                switch (option)
                {
                    case "1":
                        #region Create New Account
                        Console.Clear();
                        // input all data
                        Console.WriteLine("Enter the account title");
                        title = Console.ReadLine().Trim();

                        Console.WriteLine("Select the account type. 1) Saving 2) Current");
                        accountType = Console.ReadLine().Trim();

                        if (accountType == "1")
                        {
                            bankAccount = new SavingBankAccount
                            {
                                Title = title,
                            };
                        }
                        else if (accountType == "2")
                        {
                            bankAccount = new CurrentBankAccount
                            {
                                Title = title,
                            };
                        }

                        if (bankAccount != null)
                        {
                            bankAccountHandler.Add(bankAccount);
                            Console.WriteLine("Account created");
                            Console.WriteLine(bankAccount);
                        }
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        #endregion
                        break;
                    case "2":
                        #region Search an existing account
                        Console.Clear();
                        Console.WriteLine("Enter the account code");
                        code = Console.ReadLine().Trim();

                        Console.WriteLine($"Total accounts: {BankAccount.Total}");
                        bankAccount = bankAccountHandler.GetBankAccount(Code: code, true);
                        if (bankAccount == null)
                        {
                            Console.WriteLine($"No data found for code: {code}");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }
                        Console.WriteLine(bankAccount.ToString());
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        #endregion
                        break;
                    case "3":
                        #region Show all accounts
                        Console.Clear();
                        Console.WriteLine($"Total accounts: {BankAccount.Total}");
                         BankAccount[] bankAccounts = bankAccountHandler.GetBankAccounts();
                        foreach (var item in bankAccounts)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();
                        #endregion
                        break;
                    case "4":
                        #region PayIn amount in account
                        Console.Clear();

                        //Take account code to search
                        Console.WriteLine("Enter the account code");
                        code = Console.ReadLine().Trim();
                        bankAccount = bankAccountHandler.GetBankAccount(Code: code, true);
                        if (bankAccount == null)
                        {
                            Console.WriteLine($"No data found for code: {code}");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }

                        //Take payin amount
                        Console.WriteLine("Enter the amount to payin");
                        amount = Console.ReadLine().Trim();
                        if (amount== null)
                        {
                            Console.WriteLine($"Please enter valid amount");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }
                        bankAccount.PayIn(amount: decimal.Parse(amount));
                        Console.WriteLine($"Amount of {amount} is payed-in your Bank Account: {code}");
                        Console.WriteLine($"Your current balance is: {bankAccount.Balance}");
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();

                        #endregion
                        break;
                    case "5":
                        #region Withdraw amount from account
                        Console.Clear();

                        //Take account code to search
                        Console.WriteLine("Enter the account code");
                        code = Console.ReadLine().Trim();
                        bankAccount = bankAccountHandler.GetBankAccount(Code: code, true);
                        if (bankAccount == null)
                        {
                            Console.WriteLine($"No data found for code: {code}");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }

                        //Take payin amount
                        Console.WriteLine("Enter the amount to withdraw");
                        amount = Console.ReadLine().Trim();
                        if (amount == null)
                        {
                            Console.WriteLine($"Please enter valid amount");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }
                        bankAccount.WithDraw(amount: decimal.Parse(amount));
                        Console.WriteLine($"Amount of {amount} is withdraw from your Bank Account: {code}");
                        Console.WriteLine($"Your current balance is: {bankAccount.Balance}");
                        Console.WriteLine("Press any key for main menu");
                        Console.ReadKey();

                        #endregion
                        break;
                    case "6":
                        #region Transfer amount
                        Console.Clear();

                        //Take sender account code to search
                        Console.WriteLine("Enter the Sender account code");
                        code = Console.ReadLine().Trim();
                        var senderBankAccountCode = bankAccountHandler.GetBankAccount(Code: code, true);
                        if (senderBankAccountCode == null)
                        {
                            Console.WriteLine($"No data found for code: {code}");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }

                        //Take receiver account code to search
                        Console.WriteLine("Enter the Receiver account code");
                        code = Console.ReadLine().Trim();
                        var receiverBankAccountCode = bankAccountHandler.GetBankAccount(Code: code, true);
                        if (receiverBankAccountCode == null)
                        {
                            Console.WriteLine($"No data found for code: {code}");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }

                        //Take transfer amount
                        Console.WriteLine("Enter the amount to transfer");
                        amount = Console.ReadLine().Trim();
                        if (amount == null)
                        {
                            Console.WriteLine($"Please enter valid amount");
                            Console.WriteLine("Press any key for main menu");
                            break;
                        }
                        var transferAccountType = senderBankAccountCode.AccountType;
                        bool transferStatus = false;
                        if (transferAccountType == AccountType.Saving)
                        {
                            SavingBankAccount senderBankAccount = new SavingBankAccount();
                            var tranferStatus = senderBankAccount.Transfer(receiverBankAccountCode, decimal.Parse(amount));
                            if (tranferStatus == false)
                            {
                                Console.WriteLine($"Amount cannot be transferred.");
                                Console.WriteLine("Press any key for main menu");
                                Console.ReadKey();
                                break;
                            }
                            TransferAmountMessage(amount, senderBankAccountCode, receiverBankAccountCode);
                            break;
                        }
                        else if (transferAccountType == AccountType.Current)
                        {
                            CurrentBankAccount senderBankAccount = new CurrentBankAccount();
                            var tranferStatus = senderBankAccount.Transfer(receiverBankAccountCode, decimal.Parse(amount));
                            if (tranferStatus == false)
                            {
                                Console.WriteLine($"Amount cannot be transferred.");
                                Console.WriteLine("Press any key for main menu");
                                Console.ReadKey();
                                break;
                            }
                                TransferAmountMessage(amount, senderBankAccountCode, receiverBankAccountCode);
                            break;
                        }

                        #endregion
                        break;
                    default:
                        choice = false;
                        break;
                }

            } while (choice);
        }

        private static void TransferAmountMessage(string amount, 
            BankAccount? senderBankAccountCode,
            BankAccount? receiverBankAccountCode)
        {
            Console.WriteLine($"Amount of {amount} is transfered from Bank Account: {senderBankAccountCode} to {receiverBankAccountCode}");
            Console.WriteLine($"Your current balance is: {senderBankAccountCode.Balance}");
            Console.WriteLine("Press any key for main menu");
            Console.ReadKey();
        }
    }
}
