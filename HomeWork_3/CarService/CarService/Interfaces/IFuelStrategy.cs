using CarService.Classes.RefuelingFolder;

namespace CarService.Interfaces
{
    public interface IFuelStrategy
    {
        double GetFuelState();
        void ConsumeFuel(RefuelingStation refuelingStation);
    }
}
