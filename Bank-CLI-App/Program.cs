using Bank.Data;
using Bank.Models;
using ExtensionMethods;
using static Bank.Commons.Interfaces;

Console.WriteLine("Welcome to the Bank Solution created by Ogheneruemu Karieren");
Console.WriteLine();

AppUserModel appUser = new();

string firstName = "";
bool active = true;
while (active)
{
   Console.Write("Enter First Name: ");
   firstName = Console.ReadLine();

    if (!firstName.IsAValidName())
    {
        continue;
    }
    appUser.FirstName = firstName;
    active = false;
}

string lastName = "";
active = true;
while (active)
{
    Console.Write("Enter Last Name: ");
    lastName = Console.ReadLine();
    if (!lastName.IsAValidName())
    {
        continue;
    }
    appUser.LastName = lastName;
    active = false;
}

Console.WriteLine();
Console.Write($"Would you like to create an account {firstName} {lastName}? (Yes/No): ");
Console.WriteLine();
var toCreateAccount = Console.ReadLine();
if (toCreateAccount.Equals("Yes", StringComparison.OrdinalIgnoreCase))
{
    IContext context = new Context();
    BankAccountModel bankAccount = new(context);

    Console.WriteLine($"Cheers {firstName}! Your account has been successfully created.");
    Console.WriteLine($"Your account number is: {bankAccount.AccountNumber}");
    Console.WriteLine($"Your account number is: {bankAccount.AccountBalance}");

    context.AccountNumbers.Add(bankAccount.AccountNumber);
    context.AccountNumbers.Add(bankAccount.AccountNumber);
}