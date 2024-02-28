
namespace Bank.Models;
public class TransactionHistoryModel
{
    public List<decimal> Debits { get; set; }
    public List<decimal> Credits { get; set; }
    public string AccountStatement { get; set; }

    //Foreign key 
    public Guid BankAccountId { get; }

    //Navigation property
    public BankAccountModel BankAccount { get; }
}