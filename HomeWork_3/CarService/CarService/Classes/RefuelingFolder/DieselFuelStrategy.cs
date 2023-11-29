using CarService.Interfaces;

namespace CarService.Classes.RefuelingFolder
{
    public class DieselFuelStrategy : IFuelStrategy
    {
        private const double DieselState = 0.4;

        public double GetFuelState()
        {
            return DieselState;
        }

        public void ConsumeFuel(RefuelingStation refuelingStation)
        {
           refuelingStation.Diesel -= DieselState;
        }
    }
}
