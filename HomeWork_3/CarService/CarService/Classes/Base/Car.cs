using CarService.Enum;

namespace CarService.Classes.Base
{
    public abstract class Car 
    {
        private int numberOfWheels;
        private double engineVolume;
        private double maxFuelLevel;
        private double fuelLevel;

        public event Action? TankIsFull; //бак полный

        public string Brand { get; set; } 
        public string Model { get; set; }
        public Color Color { get; set; }
        public BodyType BodyType { get; set; }
        public int NumberOfWheels
        {
            get { return numberOfWheels; }
            set
            {
                if (value >= 0 && value <= 10) numberOfWheels = value;
                else throw new ArgumentOutOfRangeException("NumberOfWheels должно быть от 0 до 10.");
            }
        }

        public FuelType FuelType { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public double EngineVolume
        {
            get { return engineVolume; }
            set
            {
                if (value > 0) engineVolume = value;
                else throw new ArgumentOutOfRangeException("EngineVolume должно быть больше 0");
            }
        }
        public Guid StateNumber { get; }

        public double MaxFuelLevel
        {
            get { return maxFuelLevel; }
            set
            {
                if (value > 0) maxFuelLevel = value;
                else throw new ArgumentOutOfRangeException("FuelLevel должно быть больше 0");
            }
        }

        public double FuelLevel
        {
            get { return fuelLevel; }
            set
            {
                if (value > 0 && value <= MaxFuelLevel) fuelLevel = value;
                else
                {
                    if (TankIsFull != null)
                    {
                        TankIsFull();
                        FuelLevel = MaxFuelLevel;
                    }   
                } 
            }
        }

        public Car(string brand, string model, Color color, BodyType bodyType, 
            int numberOfWheels, FuelType fuelType, TransmissionType transmissionType, 
            double engineVolume, double maxFuelLevel, double fuelLevel)
        {
            Brand = brand;
            Model = model;
            Color = color;
            BodyType = bodyType;
            NumberOfWheels = numberOfWheels;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            EngineVolume = engineVolume;
            StateNumber = Guid.NewGuid();
            MaxFuelLevel = maxFuelLevel; // макисмальный уровень топлива в баке
            FuelLevel = fuelLevel; // уровень топлива для поездки
        }

        public abstract void Move();
        public abstract void Service();
        public abstract void ShiftGears();
        public abstract void TurnOnHeadlights();
        public abstract void TurnOnWipers();
    }
}
