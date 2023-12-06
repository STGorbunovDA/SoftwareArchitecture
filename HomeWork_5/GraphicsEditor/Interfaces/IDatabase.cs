using System.Collections.ObjectModel;

namespace GraphicsEditor.Interfaces
{
    public interface IDatabase
    {
        void Load();
        void Save();

        ICollection<IEntity> GetAll();
    }
}
