using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyBocket.Domain.Models;

namespace MoneyBocket.Persistence.Transactions
{
    public class TransactionConfiguration
        : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Categotry);

        }
    }
}
