namespace EditorApp.Database
{
    public class NotesTable
    {
        private Random random = new Random();

        private ICollection<NotesRecord> records;

        public ICollection<NotesRecord> GetRecords()
        {
            PrepareRecords();
            return records;
        }

        private void PrepareRecords()
        {
            if (records == null)
            {
                records = new List<NotesRecord>();
                int recordsCount = 5 + random.Next(10);
                for (int i = 0; i < recordsCount; i++)
                {
                    records.Add(new NotesRecord($"title #{i}", $"details #{i}"));
                }
            }
        }
    }
}
