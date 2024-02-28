
using static Bank.Commons.Interfaces;

namespace Bank.Models;

public class BankAccountModel
{
    private readonly IContext _context;

    public string AccountNumber { get; }
    public decimal AccountBalance { get; }

    //Foreign Key
    public Guid AppUserId { get; }
    public AppUserModel AppUser { get; set; }

    //Navigation property
    public List<TransactionHistoryModel> Transactions { get; } = [];

    public BankAccountModel(IContext context)
    {
        _context = context;
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

            if (!_context.AccountNumbers.Contains(accountNumber))
            {
                _context.AccountNumbers.Add(accountNumber);
                active = false;
                return accountNumber;
            }
        }
        throw new Exception("Failed to generate a new account number.");
    }
}
