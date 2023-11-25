namespace OperatingSystemLib.Classes
{
    public class ComputerWithoutUsingLock
    {
        private static readonly ComputerWithoutUsingLock instance = new ComputerWithoutUsingLock();

        public string Date { get; private set; }

        private ComputerWithoutUsingLock()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static ComputerWithoutUsingLock GetInstance()
        {
            return instance;
        }
    }
}
