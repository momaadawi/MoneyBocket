using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence;
using MoneyBocket.Persistence.Transactions;
using MoneyBocket.Test.Framework;
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

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            //fixture.Register<ITransactionRepository>(() => fixture.Create<TransactionRepository>());



            using (var context = new MoneyBocketDbContext(OptionBuilder.Build(ConnectionProvider.Sqlite)))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();
                var repo = new TransactionRepository(context);
                repo.Add(fixture.Create<Transaction>());

                context.Set<Transaction>().Select(x => x).Count().Should().Be(1);

            }
        }
        [Fact]
        public void Shoud_Get_Transaction_With_ID()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var entity = fixture.Create<Transaction>();

            using (var context = new MoneyBocketDbContext(OptionBuilder.Build(ConnectionProvider.Sqlite)))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var repo = new TransactionRepository(context);

                repo.Add(entity);
                repo.Get(entity.Id).Should().Be(entity);


            }
        }

        [Fact]
        public void Sould_Get_All_Transaction()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            using (var context = new MoneyBocketDbContext(OptionBuilder.Build(ConnectionProvider.Sqlite)))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var repo = new TransactionRepository(context);

                context.Set<Transaction>().AddRange(fixture.CreateMany<Transaction>(5));
                context.SaveChanges();

                repo.GetAll().Should().HaveCount(5);
            }

        }

        [Fact]
        public void Shoud_Remove_Transaction_By_Id()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            using (var context = new MoneyBocketDbContext(OptionBuilder.Build(ConnectionProvider.Sqlite)))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                var repo = new TransactionRepository(context);
                var data = fixture.CreateMany<Transaction>(5);
                var dataToRemove = data.First();
                context.Set<Transaction>().AddRange(data);
                context.SaveChanges();

                repo.Remove(dataToRemove);
                context.Transactions.Count().Should().Be(4);
            }


        }





    }
}
