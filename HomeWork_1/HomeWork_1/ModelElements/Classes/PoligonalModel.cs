using HomeWork_1.ModelElements.Classes.Base;

namespace HomeWork_1.ModelElements.Classes
{
    public class PoligonalModel
    {
        private int _id = 0;
        public int Id { get; }
        public string Name { get; set; }

        List<Poligon> _poligons = new List<Poligon>();
        List<Texture> _textures = new List<Texture>();

        public PoligonalModel(string name, Poligon poligon, Texture? texture)
        {
            Id = _id++;
            Name = name;
            _poligons.Add(poligon);
            if (texture != null)
                _textures.Add(texture);
        }




    }
}
