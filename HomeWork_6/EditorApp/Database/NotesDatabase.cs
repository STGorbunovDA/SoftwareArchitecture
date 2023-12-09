using EditorApp.Notes.Infrastructure.Persistance;

namespace EditorApp.Database
{
    public class NotesDatabase : IDatabase
    {
        private NotesTable notesTable = new NotesTable();

        public NotesTable GetNotesTable()
        {
            return notesTable;
        }
    }
}
