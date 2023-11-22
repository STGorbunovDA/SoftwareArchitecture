namespace HomeWork_1.ModelElements.Classes.Base
{
    public class Texture
    {
        private int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public Texture(string name)
        {
            Id = _id++;
            Name = name;
        }
    }
}
