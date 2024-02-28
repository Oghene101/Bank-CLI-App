
namespace Bank.Commons;

public class Interfaces
{
    public interface IContext
    {
        List<IAppUser> Users { get; }
        List<IBankAccount> BankAccounts { get; }
        List<string> AccountNumbers { get; }
    }

    public interface IAppUser
    {
        Guid Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        IBankAccount BankAccount { get; set; }
    }
    public interface IBankAccount
    {
        string AccountNumber { get; }
        decimal AccountBalance { get; }
        Guid AppUserId { get; set; }
        IAppUser AppUser { get; set; }
        List<ITransactionHistory> Transactions { get; }
    }

    public interface ITransactionHistory
    {
        List<decimal> Debits { get; set; }
        List<decimal> Credits { get; set; }
        string AccountStatement { get; set; }
        Guid BankAccountId { get; set; }
        IBankAccount BankAccount { get; }
    }
}
