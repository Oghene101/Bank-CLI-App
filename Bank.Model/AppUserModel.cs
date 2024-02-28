
namespace Bank.Models;

public class AppUserModel
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Navigation property
    public BankAccountModel BankAccount { get; }
}
