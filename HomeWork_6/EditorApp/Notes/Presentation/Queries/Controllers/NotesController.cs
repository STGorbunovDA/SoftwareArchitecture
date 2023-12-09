using EditorApp.Notes.Application.Interfaces;
using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Presentation.Queries.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteEditor _notesEditor;

        public NotesController(INoteEditor notesEditor)
        {
            _notesEditor = notesEditor;
        }

        public void RouteAddNote(Note note)
        {
            _notesEditor.Add(note);
        }

        public void RouteRemoveNote(Note note)
        {
            _notesEditor.Remove(note);
        }

        public void RouteGetAll()
        {
            _notesEditor.PrintAll();
        }

        public Note RouteGetById(int id)
        {
           return _notesEditor.GetById(id);
        }
    }
}
