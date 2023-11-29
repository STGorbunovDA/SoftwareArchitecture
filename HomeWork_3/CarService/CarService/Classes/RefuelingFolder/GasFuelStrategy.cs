using CarService.Interfaces;

namespace CarService.Classes.RefuelingFolder
{
    public class GasFuelStrategy : IFuelStrategy
    {
        private const double GasState = 0.2;

        public double GetFuelState()
        {
            return GasState;
        }

        public void ConsumeFuel(RefuelingStation refuelingStation)
        {
            refuelingStation.Gas -= GasState;
        }
    }
}
