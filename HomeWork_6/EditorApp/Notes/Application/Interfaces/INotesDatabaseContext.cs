using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Application.Interfaces
{
    public interface INotesDatabaseContext
    {
        ICollection<Note> GetAll();
        bool SaveChanges();
    }
}
