using MoneyBocket.Application.Interfaces;
using MoneyBocket.Domain.Common;
using System.Linq;

namespace MoneyBocket.Persistence.Shared
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly IDataBaseContext _dataBaseContext;

        public Repository(IDataBaseContext dataBaseContext) => this._dataBaseContext = dataBaseContext;
        public void Add(T entity) => _dataBaseContext.Set<T>().Add(entity);

        public T Get(int id) => _dataBaseContext.Set<T>().Find(id);

        public IQueryable<T> GetAll() => _dataBaseContext.Set<T>().Select(x => x);

        public void Remove(T entity) => _dataBaseContext.Set<T>().Remove(entity);
    }
}
