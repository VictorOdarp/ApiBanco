using ApiBanco.Data;
using ApiBanco.Interface;

namespace ApiBanco.Services
{
    public class AccountService : IAccountInterface
    {
        public readonly AppBankDbContext _context;

        public AccountService(AppBankDbContext context)
        {
            _context = context;
        }
    }
}
