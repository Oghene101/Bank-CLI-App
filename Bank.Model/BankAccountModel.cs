using Bank.Data;
using static Bank.Commons.Interfaces;

namespace Bank.Models;

public class BankAccountModel : IBankAccount
{
    public string AccountNumber { get; }
    public decimal AccountBalance { get; set; }

    //Foreign Key
    public Guid AppUserId { get; }
    public AppUserModel AppUser { get; set; }

    //Navigation property
    public List<TransactionHistoryModel> Transactions { get; } = [];
    IAppUser IBankAccount.AppUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    List<ITransactionHistory> IBankAccount.Transactions => throw new NotImplementedException();

    public BankAccountModel()
    {
        AccountNumber = GenerateAccountNumber();
        AccountBalance = 0.0M;
    }
    private string GenerateAccountNumber()
    {
        const int firstThreeDigits = 234;
        Random random = new();

        bool active = true;
        while (active)
        {
            int randomSevenDigits = random.Next(1000000, 9999999);

            string accountNumber = $"{firstThreeDigits}{randomSevenDigits}";

            if (!Context.AccountNumbers.Contains(accountNumber))
            {
                Context.AccountNumbers.Add(accountNumber);
                active = false;
                return accountNumber;
            }
        }
        throw new Exception("Failed to generate a new account number.");
    }
}
