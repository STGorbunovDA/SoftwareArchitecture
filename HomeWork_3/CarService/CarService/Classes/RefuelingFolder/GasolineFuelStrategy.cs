using CarService.Interfaces;

namespace CarService.Classes.RefuelingFolder
{
    public class GasolineFuelStrategy : IFuelStrategy
    {
        private const double GasolineState = 0.5;

        public double GetFuelState()
        {
            return GasolineState;
        }

        public void ConsumeFuel(RefuelingStation refuelingStation)
        {
            refuelingStation.Gasoline -= GasolineState;
        }
    }
}
