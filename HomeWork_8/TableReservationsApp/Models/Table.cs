namespace TableReservationsApp.Models
{
    public class Table
    {
        private static int _counter;
        public int Number { get; private set; }

        private readonly List<Reservation> _reservations = new List<Reservation>();

        public List<Reservation> Reservations => _reservations;

        static Table()
        {
            _counter = 0;
        }

        public Table()
        {
            Number = ++_counter;
        }

        public override string ToString()
        {
            return string.Format("Столик #{0}", Number);
        }
    }
}
