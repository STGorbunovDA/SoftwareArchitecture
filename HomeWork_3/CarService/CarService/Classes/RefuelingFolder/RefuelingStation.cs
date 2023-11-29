using CarService.Classes.Base;
using CarService.Classes.ServicesFolder;
using CarService.Enum;
using CarService.Interfaces;

namespace CarService.Classes.RefuelingFolder
{
    public class RefuelingStation : IRefuelingStation
    {
        private double _gasoline;
        private double _diesel;
        private double _gas;

        readonly IAdditionalServices _additionalServices;
        private readonly IList<Car> _places;
        RefuelingState _refuelingState;      
        event Action? LostFuel; //закончилось топливо      
        void PrintLostFuel() { MyEventHandler?.Invoke(this, new EventArgs()); }

        public event EventHandler<EventArgs>? MyEventHandler;

        public Guid Id { get; }
        public string Name { get; set; }
        public int RefuelingStationCount { get; set; }
        public double Gasoline
        {
            get { return _gasoline; }
            set
            {
                if (value > 0 && value <= 1000)
                {
                    _gasoline = value;
                }
                else
                {
                    if (LostFuel != null)
                    {
                        LostFuel();
                        PrintLostFuel();
                    }
                        
                }

            }
        }

        public double Diesel
        {
            get { return _diesel; }
            set
            {
                if (value > 0 && value <= 1000) _diesel = value;
                else
                {
                    if (LostFuel != null)
                    {
                        LostFuel();
                        PrintLostFuel();
                    }
                }
            }
        }

        public double Gas
        {
            get { return _gas; }
            set
            {
                if (value > 0 && value <= 1000) _gas = value;
                else
                {
                    if (LostFuel != null)
                    {
                        LostFuel();
                        PrintLostFuel();
                    }
                }
            }
        }

        public RefuelingStation(string name, int refuelingStationCount, double gasoline, double diesel, double gas)
        {
            Id = Guid.NewGuid();
            Name = name;
            RefuelingStationCount = refuelingStationCount;
            _places = new List<Car>();
            Gasoline = gasoline;
            Diesel = diesel;
            Gas = gas;
            _additionalServices = new AdditionalServices();
            _refuelingState = RefuelingState.Next;
        }

        public bool AddCarRefuelingStation(Car car)
        {
            if (_places.Count > RefuelingStationCount) return false;

            _places.Add(car);
            return true;
        }

        public bool RefuelCar(Car car)
        {
            if (!CheckingPresenceInCarRefuelingStation(car))
                return false;

            IFuelStrategy fuelStrategy;

            switch (car.FuelType)
            {
                case FuelType.Gasoline:
                    fuelStrategy = new GasolineFuelStrategy();
                    break;
                case FuelType.Diesel:
                    fuelStrategy = new DieselFuelStrategy();
                    break;
                case FuelType.Gas:
                    fuelStrategy = new GasFuelStrategy();
                    break;
                default:
                    throw new InvalidOperationException("Неподдерживаемый тип топлива.");
            }

            while (car.FuelLevel <= car.MaxFuelLevel && _refuelingState == RefuelingState.Next)
            {
                car.FuelLevel += fuelStrategy.GetFuelState();
                fuelStrategy.ConsumeFuel(this);
                LostFuel += () => _refuelingState = RefuelingState.Stopped;
                car.TankIsFull += () => _refuelingState = RefuelingState.Stopped;
            }

            //Реализуем доп. услуги можно создать user у которого есть денежка и тд.
            _additionalServices.WipeMirrors();
            _additionalServices.WipeWindshield();
            _additionalServices.WipeHeadlights();

            return true;
        }

        public bool DeleteCarRefuelingStation(Car car)
        {
            if (!CheckingPresenceInCarRefuelingStation(car)) return false;

            _places.Remove(car);
            return true;
        }

        bool CheckingPresenceInCarRefuelingStation(Car car)
        {
            if (_places.Count == 0)
                return false;
            Car? carSearch = _places.FirstOrDefault(sn => sn.StateNumber == car.StateNumber);

            if (carSearch is null)
                return false;

            return true;
        }
    }
}
