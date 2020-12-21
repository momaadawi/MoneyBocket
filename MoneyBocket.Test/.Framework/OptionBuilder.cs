using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MoneyBocket.Persistence;
using System;

namespace MoneyBocket.Test.Framework
{
    public static class OptionBuilder
    {

        public static DbContextOptions<MoneyBocketDbContext> Build(ConnectionProvider connectionProvider)
        {
            var option = new DbContextOptionsBuilder<MoneyBocketDbContext>();

            if (connectionProvider == ConnectionProvider.InMemoryDatabase)
            {
                return option
                     .UseInMemoryDatabase<MoneyBocketDbContext>(databaseName: $"MoneyBocketDataBase{Guid.NewGuid()}")
                     .Options;
            }

            var sqLiteConnectionBuilder = new SqliteConnectionStringBuilder() { DataSource = ":memory:" };
            var sqlLiteConnection = new SqliteConnection(sqLiteConnectionBuilder.ToString());
            return option
                            .UseSqlite(sqlLiteConnection)
                           .Options;
        }
    }
}