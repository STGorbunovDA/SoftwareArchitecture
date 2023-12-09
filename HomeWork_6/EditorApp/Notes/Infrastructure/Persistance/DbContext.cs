namespace EditorApp.Notes.Infrastructure.Persistance
{
    public abstract class DbContext
    {
        protected IDatabase _database;

        protected DbContext(IDatabase database)
        {
            _database = database;
        }

        protected abstract void OnModelCreating(ModelBuilder builder);

        public bool SaveChanges()
        {
            //TODO: Сохранение изменений в базе данных
            return true;
        }

    }
}
