using HomeWork_1.InMemoryModel.Interfaces;
using HomeWork_1.ModelElements.Classes;

namespace HomeWork_1.InMemoryModel
{
    public class ModelStore : IModelChanger
    {
        private IEnumerable<PoligonalModel> models;
        private IEnumerable<Scene> scenes;
        private IEnumerable<Flash> flashes;
        private IEnumerable<Camera> cameras;

        // Коллекция подписчиков
        private List<IModelCanngedObserver> observers;

        public ModelStore()
        {
            observers = new List<IModelCanngedObserver>();
        }

        public IEnumerable<PoligonalModel> Models
        {
            get { return models; }
            set
            {
                models = value;
                NotifyObservers();
            }
        }

        public IEnumerable<Scene> Scenes
        {
            get { return scenes; }
            set
            {
                scenes = value;
                NotifyObservers();
            }
        }

        public IEnumerable<Flash> Flashes
        {
            get { return flashes; }
            set
            {
                flashes = value;
                NotifyObservers();
            }
        }

        public IEnumerable<Camera> Cameras
        {
            get { return cameras; }
            set
            {
                cameras = value;
                NotifyObservers();
            }
        }

        // Метод для подписки на изменения в ModelStore
        public void Subscribe(IModelCanngedObserver observer)
        {
            observers.Add(observer);
        }

        // Метод для отписки от изменений в ModelStore
        public void Unsubscribe(IModelCanngedObserver observer)
        {
            observers.Remove(observer);
        }

        // Метод для уведомления всех подписчиков об изменении в ModelStore
        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.ApplyUpdateModel();
            }
        }

        // Реализация метода интерфейса IModelChanger
        public void NotifyChange(IModelChanger sender)
        {
            Console.WriteLine("Уведомление об изменении, полученное от отправителя: " + sender.GetType().Name);
            //NotifyObservers();
        }
    }
}
