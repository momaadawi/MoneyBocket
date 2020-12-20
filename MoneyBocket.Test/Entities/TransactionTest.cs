using AutoFixture;
using FluentAssertions;
using MoneyBocket.Domain.Models;
using Xunit;

namespace MoneyBocket.Test.Entities
{
    [Trait("Entity", "Transaction")]
    public class TransactionTest
    {
        [Fact]
        public void TransactionShoudHaveOneCatigory()
        {
            //arrange 

            //act 
            var fixture = new Fixture();
            var transaction = fixture.Create<Transaction>();

            transaction.Categotry.Should().NotBeNull(because: "Every Transaction Should has one Category");

        }
    }
}
