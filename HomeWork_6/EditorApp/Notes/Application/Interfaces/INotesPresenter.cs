using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Application.Interfaces
{
    public interface INotesPresenter
    {
        void PrintAll(ICollection<Note> notes);
    }
}
