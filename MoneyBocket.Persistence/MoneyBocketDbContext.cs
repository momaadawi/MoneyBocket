using Microsoft.EntityFrameworkCore;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence.Categories;
using MoneyBocket.Persistence.Shared;
using MoneyBocket.Persistence.Transactions;

namespace MoneyBocket.Persistence
{
    public class MoneyBocketDbContext : DbContext, IDataBaseContext
    {
        public MoneyBocketDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void Save() => this.SaveChanges();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured) 
            //{
            //    optionsBuilder
            //        .UseInMemoryDatabase("MoneyBocketInMemoryDb");
            //}

            base.OnConfiguring(optionsBuilder);
        }

        DbSet<T> IDataBaseContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}