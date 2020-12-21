using MoneyBocket.Application.Interfaces;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence.Shared;
using System.Linq;

namespace MoneyBocket.Persistence.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataBaseContext _dataBaseContext;

        public TransactionRepository(IDataBaseContext dataBaseContext)
        {
            this._dataBaseContext = dataBaseContext;
        }

        public void Add(Transaction entity)
        {
            _dataBaseContext.Transactions.Add(entity);
            _dataBaseContext.Save();
        }



        public Transaction Get(int id)
        {
            return _dataBaseContext.Set<Transaction>().Find(id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return _dataBaseContext.Transactions.AsQueryable();
        }

        public void Remove(Transaction entity)
        {
            _dataBaseContext.Transactions.Remove(entity);
            _dataBaseContext.Save();
        }
    }
}