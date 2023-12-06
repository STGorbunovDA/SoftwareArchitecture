using GraphicsEditor.Classes;
using GraphicsEditor.Interfaces;

public class EditorDatabase : IDatabase
{
    private readonly ProjectFile _projectFile;
    private ICollection<IEntity> _entities;
    private readonly Random _random = new();

    public EditorDatabase(ProjectFile projectFile)
    {
        _projectFile = projectFile;
        Load();
    }

    public void Load()
    {
        //TODO: Загрузка всех сущностей проекта (модели, текстуры)
    }

    public void Save()
    {
        //TODO: Сохранение текущего состояния всех сущностей проекта
    }

    public ICollection<IEntity> GetAll()
    {
        // Ленивая загрузка
        if (_entities == null)
        {
            _entities = new List<IEntity>();
            int modelsCount = _random.Next(5, 11); // 5 - 10
            for (int i = 0; i < modelsCount; i++)
                GenerateModelAndTextures();
        }

        return _entities;
    }

    private void GenerateModelAndTextures()
    {
        Model3D model = new Model3D();
        int textureCount = _random.Next(3);
        for (int i = 0; i < textureCount; i++)
        {
            Texture texture = GenerateTexture();
            model.Textures.Add(texture);
            _entities.Add(texture);
        }
        _entities.Add(model);
    }

    private Texture GenerateTexture()
    {
        return new Texture();
    }
}