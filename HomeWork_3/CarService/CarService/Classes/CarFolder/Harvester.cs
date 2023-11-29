using CarService.Classes.Base;
using CarService.Enum;
using CarService.Interfaces;

namespace CarService.Classes.CarFolder
{
    public class Harvester : Car, ISweepStreet, ITurnOnFogLights
    {
        public Harvester(string brand, string model, Color color, BodyType bodyType,
            int numberOfWheels, FuelType fuelType, TransmissionType transmissionType,
            double engineVolume, double maxFuelLevel, double fuelLevel) : base(brand,
                model, color, bodyType, numberOfWheels, fuelType, transmissionType,
                engineVolume, maxFuelLevel, fuelLevel)
        {

        }

        public override void Move()
        {
            // Реализация метода движения
        }

        public override void Service()
        {
            // Реализация метода обслуживания
        }

        public override void ShiftGears()
        {
            // Реализация метода переключения передач
        }

        public override void TurnOnHeadlights()
        {
            // Реализация метода включения фар
        }

        public override void TurnOnWipers()
        {
            // Реализация метода включения дворников
        }

        public void SweepStreet()
        {
            // Реализация метода подметания улицы
        }

        public void TurnOnFogLights()
        {
            // Реализация метода включения противотуманных фар
        }

    }
}
