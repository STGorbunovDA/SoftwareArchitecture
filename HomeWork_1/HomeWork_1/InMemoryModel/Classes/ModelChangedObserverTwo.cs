using HomeWork_1.InMemoryModel.Interfaces;

namespace HomeWork_1.InMemoryModel.Classes
{
    public class ModelChangedObserverTwo : IModelCanngedObserver
    {
        public void ApplyUpdateModel()
        {
            Console.WriteLine("Наблюдатель 2: Хранилище моделей было изменено. Выполняем обновление...");
        }
    }
}
