using EditorApp.Notes.Application.Interfaces;
using EditorApp.Notes.Domain;

namespace EditorApp.Notes.Application
{
    public class ConcreteNoteEditor : INoteEditor
    {
        private readonly INotesDatabaseContext _dbContext;
        private readonly INotesPresenter _notesPresenter;

        public ConcreteNoteEditor(INotesPresenter notesPresenter, INotesDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _notesPresenter = notesPresenter;
        }

        public void PrintAll()
        {
            _notesPresenter.PrintAll(GetAll());
        }

        public bool Add(Note item)
        {
            _dbContext.GetAll().Add(item);
            return _dbContext.SaveChanges();
        }

        public bool Edit(Note item)
        {
            if (item == null)
                return false;

            var note = GetById(item.Id);
            if (note == null)
                return false;

            note.Title = item.Title;
            note.Details = item.Details;
            note.EditDate = DateTime.Now;
            note.UserId = item.UserId;

            return _dbContext.SaveChanges();
        }

        public bool Remove(Note item)
        {
            _dbContext.GetAll().Remove(item);
            return _dbContext.SaveChanges();
        }

        public Note GetById(int id)
        {
            Note? note = _dbContext.GetAll().FirstOrDefault(p => p.Id == id);

            if (note is null) throw new Exception("Note not found.");

            return note;
        }

        public ICollection<Note> GetAll()
        {
            return _dbContext.GetAll();
        }
    }
}
