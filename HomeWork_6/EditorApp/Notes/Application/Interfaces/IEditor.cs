namespace EditorApp.Notes.Application.Interfaces
{
    public interface IEditor<T, TId> where T : class
    {
        bool Add(T item);
        bool Edit(T item);
        bool Remove(T item);
        T GetById(TId id);
        ICollection<T> GetAll();
    }
}
