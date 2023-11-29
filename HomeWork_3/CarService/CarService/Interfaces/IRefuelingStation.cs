using CarService.Classes.Base;

namespace CarService.Interfaces
{
    public interface IRefuelingStation
    {
        bool AddCarRefuelingStation(Car car);
        bool DeleteCarRefuelingStation(Car car);
        bool RefuelCar(Car car);
    }
}
