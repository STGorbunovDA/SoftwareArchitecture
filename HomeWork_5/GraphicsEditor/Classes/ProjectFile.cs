namespace GraphicsEditor.Classes
{
    public class ProjectFile
    {
        public int Setting1 { get; } = 1;
        public string Setting2 { get; } = "..";
        public bool Setting3 { get; } = false;
        public string FileName { get; }

        public ProjectFile(string fileName)
        {
            FileName = fileName;
        }
    }
}
