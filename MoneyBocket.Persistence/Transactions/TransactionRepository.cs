using MoneyBocket.Application.Interfaces;
using MoneyBocket.Domain.Models;
using MoneyBocket.Persistence.Shared;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public IQueryable<Transaction> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactionWithCategoryId(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Transaction entity)
        {
            throw new System.NotImplementedException();
        }
    }
}