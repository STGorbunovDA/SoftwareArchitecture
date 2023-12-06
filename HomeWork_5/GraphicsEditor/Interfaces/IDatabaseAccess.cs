using GraphicsEditor.Classes;

namespace GraphicsEditor.Interfaces
{
    public interface IDatabaseAccess
    {
        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
        ICollection<Texture> GetAllTextures();
        ICollection<Model3D> GetAllModels();

    }
}
