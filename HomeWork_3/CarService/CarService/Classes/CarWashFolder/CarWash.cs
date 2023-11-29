using CarService.Classes.Base;
using CarService.Classes.ServicesFolder;
using CarService.Interfaces;

namespace CarService.Classes.CarWashFolder
{
    public class CarWash : ICarWash
    {
        readonly IAdditionalServices _additionalServices;
        private readonly IList<Car> _places;

        public Guid Id { get; }
        public string Name { get; set; }
        public int CarWashCount { get; set; }

        public CarWash(string name, int carWashCount)
        {
            Id = Guid.NewGuid();
            Name = name;
            CarWashCount = carWashCount;
            _additionalServices = new AdditionalServices();
            _places = new List<Car>();
        }

        public bool AddCarCarWash(Car car)
        {
            if (_places.Count > CarWashCount) return false;

            _places.Add(car);
            return true;
        }

        public bool WashCar(Car car)
        {
            if (!CheckingPresenceInCarRefuelingStation(car))
                return false;

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
