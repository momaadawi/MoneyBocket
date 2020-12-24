using MoneyBocket.Application.Interfaces;
using MoneyBocket.Application.Transactions.Models;
using MoneyBocket.Domain.Models;
using System.Linq;

namespace MoneyBocket.Application.Transactions.Queries
{
    public class TransactionQueries
    {
        private readonly ITransactionRepository _trasactionRepository;

        public TransactionQueries(ITransactionRepository trasactionRepository)
        {
            this._trasactionRepository = trasactionRepository;
        }


        public IQueryable<TrasactionModel> GetAllranscationsQuery()
        {
            return _trasactionRepository.GetAll().Select(t =>
                new TrasactionModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Date = t.Date,
                    Category = t.Categotry
                });
        }

        public void RemoveTransaction(Transaction entity)
        {
            _trasactionRepository.Remove(entity);
        }
    }
}
