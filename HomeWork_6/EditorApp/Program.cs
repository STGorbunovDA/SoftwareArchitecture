using EditorApp.Database;
using EditorApp.Notes.Application;
using EditorApp.Notes.Infrastructure.Persistance;
using EditorApp.Notes.Presentation.Queries.Controllers;
using EditorApp.Notes.Presentation.Queries.Views;

namespace EditorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notesController = new NotesController(
                new ConcreteNoteEditor(
                    new NotesConsolePresenter(), 
                    new DatabaseContext(
                        new NotesDatabase())));

            notesController.RouteGetAll();
            notesController.RouteRemoveNote(notesController.RouteGetById(1));
            notesController.RouteGetAll();
        }
    }
}
