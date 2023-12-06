using GraphicsEditor.Classes;
using GraphicsEditor.Interfaces;

public class EditorDatabaseAccess : IDatabaseAccess
{
    private readonly IDatabase _editorDatabase;

    public EditorDatabaseAccess(IDatabase editorDatabase)
    {
        _editorDatabase = editorDatabase;
    }

    public void AddEntity(IEntity entity)
    {
        _editorDatabase.GetAll().Add(entity);
    }

    public void RemoveEntity(IEntity entity)
    {
        _editorDatabase.GetAll().Remove(entity);
    }

    public ICollection<Texture> GetAllTextures()
    {
        ICollection<Texture> textures = new List<Texture>();

        foreach (IEntity entity in _editorDatabase.GetAll())
        {
            if (entity is Texture texture)
            {
                textures.Add(texture);
            }
        }
        return textures;
    }

    public ICollection<Model3D> GetAllModels()
    {
        ICollection<Model3D> models = new List<Model3D>();

        foreach (IEntity entity in _editorDatabase.GetAll())
        {
            if (entity is Model3D model)
            {
                models.Add(model);
            }
        }
        return models;
    }
}