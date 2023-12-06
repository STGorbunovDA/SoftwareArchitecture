using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Classes
{
    public class Model3D : IEntity
    {
        private static int _counter = 10000;
        private int _id;
        public ICollection<Texture> Textures = new List<Texture>();

        static Model3D()
        {
            _counter = 10000;
        }

        public Model3D()
        {
            _id = ++_counter;
        }

        public Model3D(ICollection<Texture> textures)
        {
            Textures = textures ?? throw new ArgumentNullException(nameof(textures));
            _id = ++_counter;
        }

        public int GetId()
        {
            return _id;
        }

        public ICollection<Texture> GetTextures()
        {
            return Textures;
        }

        public override string ToString()
        {
            return $"Model #{_id}";
        }
    }
}
