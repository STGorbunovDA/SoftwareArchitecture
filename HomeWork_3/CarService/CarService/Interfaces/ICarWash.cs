using CarService.Classes.Base;

namespace CarService.Interfaces
{
    public interface ICarWash
    {
        bool AddCarCarWash(Car car);
        bool WashCar(Car car);
        bool DeleteCarRefuelingStation(Car car);
    }
}
