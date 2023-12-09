using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Application.Interfaces
{
    public interface INoteEditor : IEditor<Note, int>
    {
        void PrintAll();
    }
}
