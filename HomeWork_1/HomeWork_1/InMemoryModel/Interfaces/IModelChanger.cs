namespace HomeWork_1.InMemoryModel.Interfaces
{
    public interface IModelChanger
    {
        void NotifyChange(IModelChanger sender);
    }
}
