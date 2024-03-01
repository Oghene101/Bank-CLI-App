using System.Globalization;
using static Bank.Commons.Interfaces;

namespace Bank.Models;

public class AppUserModel : IAppUser
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Navigation property
    public IBankAccount BankAccount { get; }

    public override string ToString()
    {
        return $"{Id}: {FirstName} {LastName}";
    }
}
