using CarService.Classes.CarFolder;
using CarService.Classes.RefuelingFolder;
using CarService.Enum;
namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Harvester harvester = new Harvester("PIKA", "08-d", Color.Blue, BodyType.Van, 4, FuelType.Diesel, 
                TransmissionType.MKPP, 450, 2500, 1000);

            RefuelingStation refuelingStation = new RefuelingStation("Заправка №1", 2, 1000, 1000, 1000);
            refuelingStation.MyEventHandler += State_MyEventHandler;

            //Данные методы можно объеденить 
            refuelingStation.AddCarRefuelingStation(harvester);
            refuelingStation.RefuelCar(harvester);
            refuelingStation.DeleteCarRefuelingStation(harvester);
        }

        private static void State_MyEventHandler(object? sender, EventArgs e)
        {
            if (sender is RefuelingStation refuelingStation)
            {
                Console.WriteLine("Закончилось топливо на заправке");
                Console.WriteLine($"Бензин: {Math.Round(refuelingStation.Gasoline)}\n" +
                                  $"Дизель: {Math.Round(refuelingStation.Diesel)}\n" +
                                  $"Газ:{Math.Round(refuelingStation.Gas)}");
            }
        }
    }
}
