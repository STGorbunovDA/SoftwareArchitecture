namespace EditorApp.Notes.Domain
{
    public class Note
    {
        public int UserId { get; set; }
        public int Id { get; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; }
        public DateTime EditDate { get; set; }

        public Note(int id, int userId, string title, string details, DateTime creationDate)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Details = details;
            CreationDate = creationDate;
        }

        public override string ToString()
        {
            return $"Note{{userId={UserId}, id={Id}, title='{Title}', details='{Details}', creationDate={CreationDate}, editDate={EditDate}}}";
        }
    }
}
