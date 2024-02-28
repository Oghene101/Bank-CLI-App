using static Bank.Commons.Interfaces;

namespace Bank.Data
{
    public  class Context : IContext
    {
        public List<IAppUser> Users { get; } = [];
        public List<IBankAccount> BankAccounts { get; } = [];
        public List<string> AccountNumbers { get; } = [];
    }
}
