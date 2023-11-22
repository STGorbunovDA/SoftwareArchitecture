using HomeWork_1.InMemoryModel.Interfaces;

namespace HomeWork_1.InMemoryModel.Classes
{
    public class ModelChangedObserverOne : IModelCanngedObserver
    {
        public void ApplyUpdateModel()
        {
            Console.WriteLine("Наблюдатель 1: Хранилище моделей было изменено. Выполняем обновление...");
        }
    }
}
