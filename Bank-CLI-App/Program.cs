using Bank.Data;
using Bank.Models;
using ExtensionMethods;
using System.Text;
using static Bank.Logic.BankActions;

Console.OutputEncoding = Encoding.UTF8; // Use UTF-8 encoding

Console.WriteLine("Welcome to the Bank Solution created by Ogheneruemu Karieren");
Console.WriteLine();

bool active = true;
BankAccountModel bankAccount = null;
while (active)
{
    Menu();
    (bool isValid, int selection ) = Console.ReadLine().IsAValidNumber();

    if (isValid)
    {
        switch (selection)
        {
            case 1:
                Console.Clear();
                bankAccount = CreateAccount();
                break;
            case 3:
                Console.Clear();
                if ( bankAccount != null)
                {
                    WithdrawFromAccount(bankAccount);
                }
                Console.WriteLine("There is no existing account to withdraw from!");
                break;
            case 4:
                Console.Clear();
                if ( bankAccount != null)
                {
                    FundAccount(bankAccount);
                }
                Console.WriteLine("There is no existing account to fund!");
                break;
            case 5:
                Console.Clear();
                active = false;
                break;
            default:
                Console.Clear();
                Console.WriteLine("Enter a valid option.");
                break;
        }
    }
}

Console.WriteLine("\nApp Users:");
foreach (var user in Context.Users)
{
    Console.WriteLine(user);
}

void Menu()
{
    Console.WriteLine("\n\nEnter 1 to create an account\n" +
                    "Enter 2 to make a transfer\n" +
                    "Enter 3 to make a withdrawal\n" +
                    "Enter 4 to fund account\n" +
                    "Enter 5 to exit application");
}
