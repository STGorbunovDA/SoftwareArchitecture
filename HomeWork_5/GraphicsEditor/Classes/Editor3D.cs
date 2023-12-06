using GraphicsEditor.Interfaces;

namespace GraphicsEditor.Classes
{
    public class Editor3D : IUILayer
    {
        private ProjectFile _projectFile;
        private IBusinessLogicalLayer _businessLogicalLayer;
        private IDatabaseAccess _databaseAccess;
        private IDatabase _database;

        List<Model3D> models;
        List<Texture> textures;

        public Editor3D()
        {
            models = new List<Model3D>();
            textures = new List<Texture>();
            Initialize();
        }

        private void Initialize()
        {
            _database = new EditorDatabase(_projectFile);
            _databaseAccess = new EditorDatabaseAccess(_database);
            _businessLogicalLayer = new EditorBusinessLogicalLayer(_databaseAccess);
        }

        public void OpenProject(string fileName)
        {
            _projectFile = new ProjectFile(fileName);
            Initialize();
        }

        public void ShowProjectSettings()
        {
            Console.WriteLine("*** Project v1 ***");
            Console.WriteLine("******************");
            Console.WriteLine($"fileName: {_projectFile.FileName}");
            Console.WriteLine($"setting1: {_projectFile.Setting1}");
            Console.WriteLine($"setting2: {_projectFile.Setting2}");
            Console.WriteLine($"setting3: {_projectFile.Setting3}");
            Console.WriteLine("******************");
        }

        public void SaveProject()
        {
            Console.WriteLine("Изменения успешно сохранены.");
            _database.Save();
        }

        public void PrintAllModels()
        {
            models = (List<Model3D>)_businessLogicalLayer.GetAllModels();

            for (int i = 0; i < models.Count; i++)
            {
                Console.WriteLine($"==={i}===");
                Console.WriteLine(models[i]);
                foreach (Texture texture in models[i].Textures)
                    Console.WriteLine($"\t{texture}");
            }
        }

        public void PrintAllTextures()
        {
            textures = (List<Texture>)_businessLogicalLayer.GetAllTextures();
            for (int i = 0; i < textures.Count; i++)
            {
                Console.WriteLine($"==={i}===");
                Console.WriteLine(textures[i]);
            }
        }

        public void RenderAll()
        {
            Console.WriteLine("Подождите ...");
            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            _businessLogicalLayer.RenderAllModels();
            long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTime;
            Console.WriteLine($"Операция выполнена за {endTime} мс.");
        }

        public void RenderModel(int i)
        {
            models = (List<Model3D>)_businessLogicalLayer.GetAllModels();
            if (i < 0 || i > models.Count - 1)
                throw new InvalidOperationException("Номер модели указан некорректно.");
            

            Console.WriteLine("Подождите ...");
            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            _businessLogicalLayer.RenderModel(models[i]);
            long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - startTime;
            Console.WriteLine($"Операция выполнена за {endTime} мс.");
        }

        public void AddModel()
        {
            Model3D newModel = new Model3D();
            // Здесь может быть код для настройки новой модели

            _businessLogicalLayer.AddModel3D(newModel);
            models.Add(newModel);
            Console.WriteLine("Модель успешно добавлена.");
        }

        public void RemoveModel(int i)
        {
            models = (List<Model3D>)_businessLogicalLayer.GetAllModels();
            if (i < 0 || i > models.Count - 1)
                throw new InvalidOperationException("Номер модели указан некорректно.");

            Model3D modelToRemove = models[i];
            _businessLogicalLayer.RemoveModel3D(modelToRemove);
            models.RemoveAt(i);
            Console.WriteLine("Модель успешно удалена.");
        }
    }
}