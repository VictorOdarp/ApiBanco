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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountModel>()
                .HasOne(a => a.Holder)
                .WithOne(u => u.Account)
                .HasForeignKey<UserModel>(u => u.AccountId);
        }
    }
}
