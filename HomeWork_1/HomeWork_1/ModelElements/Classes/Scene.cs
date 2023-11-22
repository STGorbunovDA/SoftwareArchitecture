namespace HomeWork_1.ModelElements.Classes
{
    public class Scene
    {
        private int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }

        List<PoligonalModel> _poligonalModels = new List<PoligonalModel>();
        List<Flash> _flashes = new List<Flash>();
        List<Camera> _cameras = new List<Camera>();

        public Scene(string name, 
            PoligonalModel poligonalModel, Flash flash,
            Camera camera)
        {
            Id = _id++;
            Name = name;
            _poligonalModels.Add(poligonalModel);
            _flashes.Add(flash);
            _cameras.Add(camera);
        }

        // Какой-то метод1
        // Какой-то метод2
    }
}
