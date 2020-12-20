using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MoneyBocket.Application.Interfaces;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence;
using MoneyBocket.Persistence.Transactions;
using System.Linq;
using Xunit;

namespace MoneyBocket.Test.Domains
{
    [Trait("Domain", "TransactionRepository")]
    public class TransactionRepositoryTest
    {
        [Fact]
        public void AddTransaction()
        {
            //var options = new DbContextOptionsBuilder<MoneyBocketDbContext>()
            //                     .UseInMemoryDatabase<MoneyBocketDbContext>(databaseName: $"MoneyBocketDataBase{Guid.NewGuid()}")
            //                     .Options;

            var sqLiteConnectionBuilder = new SqliteConnectionStringBuilder() { DataSource = ":memory:" };
            var sqlLiteConnection = new SqliteConnection(sqLiteConnectionBuilder.ToString());
            var options = new DbContextOptionsBuilder<MoneyBocketDbContext>()
                                .UseSqlite(sqlLiteConnection)
                                .Options;


            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Register<ITransactionRepository>(() => fixture.Create<TransactionRepository>());



            var data = fixture.CreateMany<Transaction>(5);

            using (var context = new MoneyBocketDbContext(options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();
                var repo = new TransactionRepository(context);
                repo.Add(fixture.Create<Transaction>());

                context.Set<Transaction>().Select(x => x).Count().Should().Be(1);

            }
        }



    }
}
