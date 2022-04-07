// See https://aka.ms/new-console-template for more information
using Handlers;
using Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BankAccountHandler bankAccountHandler = new BankAccountHandler(100);

            IBankAccountHandler bankAccountHandler = new BankAccountCollectionHandler();
            //IBankAccountHandler bankAccountHandler = new BankAccountHandler(100);


        }
    }
}
