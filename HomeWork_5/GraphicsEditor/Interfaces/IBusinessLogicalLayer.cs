using GraphicsEditor.Classes;
using System.Collections.ObjectModel;

namespace GraphicsEditor.Interfaces
{
    public interface IBusinessLogicalLayer
    {
        ICollection<Model3D> GetAllModels();
        ICollection<Texture> GetAllTextures();
        void RenderModel(Model3D model);
        void RenderAllModels();
        void RemoveModel3D(Model3D model);
        void AddModel3D(Model3D model);

    }
}
