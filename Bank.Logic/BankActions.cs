using Bank.Data;
using Bank.Models;
using ExtensionMethods;
using System.Globalization;
using static Bank.Commons.Interfaces;
using static Bank.Logic.Enums;

namespace Bank.Logic;

public static class BankActions
{
    public static void PerformAction(TransactionType transactionType, BankAccountModel bankAccount)
    {
        CultureInfo nigerianCulture = new("en-NG");

        switch (transactionType)
        {
            case TransactionType.Funding:
                bool fundIsActive = true;
                while (fundIsActive)
                {
                    Console.Write("Enter amount to fund account: ");
                    var amountToFundAccount =  Console.ReadLine();
                    (bool isValidFund, int fundValue) = amountToFundAccount.IsAValidNumber();

                    decimal amount;
                    if (isValidFund)
                    {
                        amount = bankAccount.AccountBalance += fundValue;
                        Console.WriteLine($"You have successfully funded your account with {amount.ToString("C", nigerianCulture)}.");
                        fundIsActive = false;
                    }
                }
                break;
            case TransactionType.Transfer:
                // Implement transfer logic
                break;
            case TransactionType.Withdraw:
                bool withdrawIsActive = true;
                while (withdrawIsActive)
                {
                    Console.Write("How much do you want to withdraw? ");
                    (bool isValidWithdraw, int withdrawalAmount) = Console.ReadLine().IsAValidNumber();

                    if ((isValidWithdraw) && (withdrawalAmount <= bankAccount.AccountBalance))
                    {
                        var balance = bankAccount.AccountBalance - withdrawalAmount;

                        Console.WriteLine("Your withdrawal was successful.");
                        Console.WriteLine($"Your balance is: {balance.ToString("C", nigerianCulture)}");
                        withdrawIsActive = false;
                    }
                    if (withdrawalAmount > bankAccount.AccountBalance)
                    {
                        Console.WriteLine($"Withdrawal request ({withdrawalAmount.ToString("C", nigerianCulture)}) is more than available balance ({bankAccount.AccountBalance})!");
                    }
                }

                break;
            case TransactionType.CreateAccount:
                (string firstName, string _) = CreateAppUser();

                Console.WriteLine($"\nCheers {firstName}! Your account has been successfully created.");
                Console.WriteLine($"Your account number is: {bankAccount.AccountNumber}");
                Console.WriteLine($"Your account balance is: {bankAccount.AccountBalance.ToString("C", nigerianCulture)}");

                Context.AccountNumbers.Add(bankAccount.AccountNumber);
                Context.BankAccounts.Add(bankAccount);

                FundAccount(firstName, bankAccount);
                break;
            default:
                Console.WriteLine("Invalid transaction type.");
                break;
        }
    }
    public static (string, string) CreateAppUser()
    {
        AppUserModel appUser = new();

        string firstName;
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

        string lastName;
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

        Context.Users.Add(appUser);
        return (appUser.FirstName, appUser.LastName);
    }
    public static BankAccountModel CreateAccount()
    {
        BankAccountModel bankAccount = null;

        Thread.Sleep(1000);
        Console.Clear();
        Console.Write("Are you sure you want to an account? (Y/N): ");
        var responseToCreatingAccount = Console.ReadLine();

        if (responseToCreatingAccount.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            bankAccount = new();
            PerformAction(TransactionType.CreateAccount, bankAccount);
        }
        return bankAccount;
    }
    public static void FundAccount(string firstName, BankAccountModel bankAccount)
    {
        CultureInfo nigerianCulture = new("en-NG");

        Console.Write($"\n{firstName}, are you sure you want to fund your account? (Y/N): ");
        var responseToFundingAccount = Console.ReadLine();
        if (responseToFundingAccount.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            PerformAction(TransactionType.Funding, bankAccount);
            Console.WriteLine($"{firstName} your new account balance is {bankAccount.AccountBalance.ToString("C", nigerianCulture)}");
        }
    }
    public static void FundAccount(BankAccountModel bankAccount)
    {
        CultureInfo nigerianCulture = new("en-NG");

        Console.Write("\n Are you sure you want to fund your account? (Y/N): ");
        var responseToFundingAccount = Console.ReadLine();
        if (responseToFundingAccount.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            PerformAction(TransactionType.Funding, bankAccount);
            Console.WriteLine($"Your new account balance is {bankAccount.AccountBalance.ToString("C", nigerianCulture)}");
        }
    }

    public static void WithdrawFromAccount(BankAccountModel bankAccount)
    {
        Console.WriteLine("Are you sure you want to witdraw from your account? (Y/N)");
        var responseToWithdrawingFromAccount = Console.ReadLine();

        if (responseToWithdrawingFromAccount.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            PerformAction(TransactionType.Withdraw, bankAccount);
        }
    }
}
