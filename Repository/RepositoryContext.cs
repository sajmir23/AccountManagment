using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, Role, int>
    {
        public RepositoryContext(DbContextOptions options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            
            modelBuilder.Entity<User>().HasIndex(o=>o.PhoneNumber).IsUnique();
            modelBuilder.Entity<User>().HasIndex(o=>o.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(o=>o.UserName).IsUnique();

            modelBuilder.Entity<Currencies>().HasIndex(o=>o.Code).IsUnique();
            modelBuilder.Entity<Currencies>().Property(c => c.ExchangeRate).HasPrecision(18,6);

            modelBuilder.Entity<BankAccounts>().Property(c => c.Balance).HasPrecision(18,2);
            modelBuilder.Entity<BankAccounts>().HasIndex(a=> new { a.Code, a.ClientId }).IsUnique();

            modelBuilder.Entity<BankTransactions>().Property(c => c.Amount).HasPrecision(18,2);
            modelBuilder.Entity<Products>().Property(c => c.Price).HasPrecision(18,2);
            modelBuilder.Entity<Category>().HasIndex(c => c.Code).IsUnique();
        }

        public DbSet<BankTransactions> BankTransactions { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<TransactionsHistory> TransactionsHistory { get; set; }
    }
}
