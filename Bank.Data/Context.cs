using static Bank.Commons.Interfaces;

namespace Bank.Data
{
    public  class Context : IContext
    {
        public static List<IAppUser> Users { get; } = [];
        public static List<IBankAccount> BankAccounts { get; } = [];
        public static List<string> AccountNumbers { get; } = [];
    }
}
