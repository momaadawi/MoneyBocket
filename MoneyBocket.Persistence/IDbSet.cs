using MoneyBocket.Domain.Common;

namespace MoneyBocket.Persistence
{
    public interface IDbSet<T> where T : class, IEntity
    {
    }
}