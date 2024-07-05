using ApiBanco.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBanco.Data
{
    public class AppBankDbContext : DbContext
    {
        public AppBankDbContext(DbContextOptions<AppBankDbContext> options) : base(options)
        {

        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
