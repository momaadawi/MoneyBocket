using Microsoft.EntityFrameworkCore;
using MoneyBocket.Domain.Common;
using MoneyBocket.Domain.Models;


namespace MoneyBocket.Persistence.Shared
{
    public interface IDataBaseContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Category> Categories { get; set; }
        void Save();

        DbSet<T> Set<T>() where T : class, IEntity;


    }
}