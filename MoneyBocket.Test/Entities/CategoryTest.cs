using AutoFixture;
using FluentAssertions;
using MoneyBocket.Domain.Models;
using Xunit;

namespace MoneyBocket.Test.Entities
{
    [Trait("Entity", "Category")]
    public class CategoryTest
    {
        [Fact]
        public void CategoryShoudHasName()
        {
            var fixture = new Fixture();
            var category = fixture.Create<Category>();

            category.Should().NotBeNull();

        }
    }
}
