using EditorApp.Database;
using EditorApp.Notes.Application.Interfaces;
using EditorApp.Notes.Domain;
using EditorApp.Notes.Infrastructure.Persistance.Configuration;

namespace EditorApp.Notes.Infrastructure.Persistance
{
    public class DatabaseContext : DbContext, INotesDatabaseContext
    {
        public DatabaseContext(IDatabase database): base(database)
        {
        }

        public ICollection<Note> GetAll()
        {
            var notesList = new List<Note>();
            //TODO: Этого кастинга быть не должно, тут должен работать внутренний механизм фреймворка

            var records = ((NotesDatabase)_database).GetNotesTable().GetRecords();

            foreach (var record in records)
            {
                notesList.Add(
                        new Note(
                            record.Id,
                            record.UserId,
                            record.Title,
                            record.Details,
                            record.CreationDate
                ));
            }

            return notesList;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
        }

    }
}
