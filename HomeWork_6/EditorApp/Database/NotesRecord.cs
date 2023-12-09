namespace EditorApp.Database
{
    public class NotesRecord
    {
        private static int counter;

        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public NotesRecord(string title, string details)
        {
            Id = ++counter;
            UserId = 20001;
            Title = title;
            Details = details;
            CreationDate = DateTime.Now;
        }
    }
}
