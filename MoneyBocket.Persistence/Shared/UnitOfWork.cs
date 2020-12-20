namespace MoneyBocket.Persistence.Shared
{
    public class UnitOfWork
    {
        private readonly IDataBaseContext _dataBaseContext;

        public UnitOfWork(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        void Save()
        {
            _dataBaseContext.Save();
        }
    }

}
