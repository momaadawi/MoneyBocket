using AutoFixture;
using FluentAssertions;
using MoneyBocket.Application.Interfaces;
using MoneyBocket.Application.Transactions.Queries;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence;
using MoneyBocket.Persistence.Transactions;
using MoneyBocket.Test.Framework;
using Moq;
using System.Linq;
using Xunit;

namespace MoneyBocket.Test.ApplicationServices
{
    public class TransactionQueryTest
    {
        [Fact]
        public void Shoud_Call_GetAll_From_Repository()
        {
            var fixture = new Fixture().Customize(new AutoFixture.AutoMoq.AutoMoqCustomization());

            var mapMock = fixture.Freeze<Mock<ITransactionRepository>>();

            var sut = fixture.Create<TransactionQueries>();
            sut.GetAllranscationsQuery();

            mapMock.Verify(x => x.GetAll());
        }

        [Fact]
        public void Shoud_GetAllTransactions_And_Return_Same_Count()
        {
            var fixture = new Fixture();
            using MoneyBocketDbContext context = new ContextInilizer().WithSqlLite().CreateContext();

            context.Set<Transaction>().Add(fixture.Create<Transaction>());
            context.SaveChanges();

            fixture.Register(() => new TransactionQueries(new TransactionRepository(context)));

            var sut = fixture.Create<TransactionQueries>();
            sut.GetAllranscationsQuery().Should().HaveCount(1);
        }

        [Fact]
        public void Shoud_Add_Transaction()
        {
            var fixture = new Fixture();

            using var context = new ContextInilizer().WithSqlLite().CreateContext();
            var sutTransaction = fixture.Create<Transaction>();

            context.Set<Transaction>().Add(sutTransaction);
            context.SaveChanges();

            fixture.Register(() => new TransactionQueries(new TransactionRepository(context)));

            var sut = fixture.Create<TransactionQueries>();
            sut.RemoveTransaction(sutTransaction);

            context.Set<Transaction>().Select(x => x).Should().HaveCount(0);

        }

    }
}