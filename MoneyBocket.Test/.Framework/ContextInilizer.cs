using Microsoft.EntityFrameworkCore;
using MoneyBocket.Persistence;
using System;

namespace MoneyBocket.Test.Framework
{
    public class ContextInilizer
    {
        private Lazy<MoneyBocketDbContext> _context;

        private static MoneyBocketDbContext CreateContext(ConnectionProvider provider)
        {
            var context = new MoneyBocketDbContext(OptionBuilder.Build(provider));
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        public ContextInilizer WithSqlLite()
        {
            _context = new Lazy<MoneyBocketDbContext>(CreateContext(ConnectionProvider.Sqlite));
            return this;
        }

        public MoneyBocketDbContext CreateContext()
        {
            return _context.Value;
        }
    }
}
