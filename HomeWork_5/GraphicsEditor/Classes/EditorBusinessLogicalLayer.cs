using GraphicsEditor.Classes;
using GraphicsEditor.Interfaces;

public class EditorBusinessLogicalLayer : IBusinessLogicalLayer
{
    private readonly IDatabaseAccess _databaseAccess;
    private readonly Random _random = new();

    public EditorBusinessLogicalLayer(IDatabaseAccess databaseAccess)
    {
        _databaseAccess = databaseAccess;
    }

    public ICollection<Model3D> GetAllModels()
    {
        return _databaseAccess.GetAllModels();
    }

    public ICollection<Texture> GetAllTextures()
    {
        return _databaseAccess.GetAllTextures();
    }

    public void RenderModel(Model3D model)
    {
        ProcessRender(model);
    }

    public void RenderAllModels()
    {
        foreach (Model3D model in GetAllModels())
        {
            ProcessRender(model);
        }
    }

    private void ProcessRender(Model3D model)
    {
        try
        {
            Thread.Sleep(2500 - _random.Next(2000));
        }
        catch (ThreadInterruptedException e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    public void AddModel3D(Model3D model)
    {
        _databaseAccess.AddEntity(model);
    }

    public void RemoveModel3D(Model3D model)
    {
        _databaseAccess.RemoveEntity(model);
    }
}