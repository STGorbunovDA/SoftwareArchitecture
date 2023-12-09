namespace EditorApp.Notes.Infrastructure.Persistance
{
    public class ModelBuilder
    {
        public ModelBuilder ApplyConfiguration<T>(IModelConfiguration<T> configuration)
        {
            //TODO: добавление конфигурации маппинга объекта некоторого типа к структуре таблицы базы данных ...
            return this;
        }
    }
}
