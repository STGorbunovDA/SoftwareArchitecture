using HomeWork_1.InMemoryModel;
using HomeWork_1.InMemoryModel.Classes;
using HomeWork_1.InMemoryModel.Interfaces;
using HomeWork_1.ModelElements.Classes;
using HomeWork_1.ModelElements.Classes.Base;
using HomeWork_1.ModelElements.Enum;

namespace HomeWork_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляра ModelStore
            ModelStore modelStore = new ModelStore();

            var poligonModel1 = new PoligonalModel("Полигон1", new Poligon(new Point3D(2, 1, 6)), new Texture("текстура1"));
            var poligonModel2 = new PoligonalModel("Полигон2", new Poligon(new Point3D(3, 7, 2)), new Texture("текстура2"));
            var poligonModel3 = new PoligonalModel("Полигон3", new Poligon(new Point3D(5, 3, 8)), new Texture("текстура3"));

            var flash1 = new Flash("Свет1", new Point3D(2, 1, 6), new Angle3D(new Point3D(12, 6, 7)), Color.Blue, 12f);
            var flash2 = new Flash("Свет1", new Point3D(12, 11, 16), new Angle3D(new Point3D(13, 3, 8)), Color.Blue, 12f);
            var flash3 = new Flash("Свет1", new Point3D(3, 5, 4), new Angle3D(new Point3D(10, 2, 9)), Color.Blue, 12f);

            var camera1 = new Camera("Камера1", new Point3D(2, 1, 6), new Angle3D(new Point3D(12, 6, 7)));
            var camera2 = new Camera("Камера2", new Point3D(12, 10, 4), new Angle3D(new Point3D(2, 21, 0)));

            // Создание и заполнение коллекций
            var models = new[] { poligonModel1, poligonModel2 };
            var scenes = new[] { new Scene("Scena1", poligonModel3, flash1, camera1), new Scene("Scena2", poligonModel2, flash3, camera2) };
            var flashes = new[] { flash2, flash3 };
            var cameras = new[] { camera1, camera2 };

            // Установка коллекций в ModelStore
            modelStore.Models = models;
            modelStore.Scenes = scenes;
            modelStore.Flashes = flashes;
            modelStore.Cameras = cameras;

            // Создание экземпляра наблюдателя 1
            ModelChangedObserverOne observer = new();

            // Создание экземпляра наблюдателя 2
            ModelChangedObserverTwo observer2 = new();

            // Подписка на изменения в ModelStore №1
            modelStore.Subscribe(observer);

            // Подписка на изменения в ModelStore №2
            modelStore.Subscribe(observer2);

            modelStore.NotifyChange(modelStore);

            // Изменение коллекций в ModelStore (для демонстрации уведомлений наблюдателю)
            modelStore.Models = new[] { poligonModel1, poligonModel2, poligonModel3 };
            modelStore.Scenes = new[] { new Scene("Scena1", poligonModel3, flash1, camera1),
                                        new Scene("Scena2", poligonModel2, flash3, camera2),
                                        new Scene("Scena3", poligonModel1, flash3, camera2) };
            modelStore.Flashes = new[] { flash3 };
            modelStore.Cameras = new[] { camera2 };

            // Отписка от изменений в ModelStore
            modelStore.Unsubscribe(observer);

            // Изменение коллекций в ModelStore (больше не будет уведомлений наблюдателю)
            modelStore.Models = new[] { poligonModel1, poligonModel2 };
            modelStore.Scenes = new[] { new Scene("Scena4", poligonModel1, flash2, camera2),
                                        new Scene("Scena5", poligonModel1, flash3, camera2) };
            modelStore.Flashes = new[] { flash1 };
            modelStore.Cameras = new[] { camera1 };

            Console.ReadLine();
        }

       
    }  
}