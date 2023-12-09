using EditorApp.Notes.Application.Interfaces;
using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Presentation.Queries.Views
{
    public class NotesConsolePresenter : INotesPresenter
    {
        public void PrintAll(ICollection<Note> notes)
        {
            foreach (var note in notes)
            {
                Console.WriteLine(note);
            }
        }
    }
}
