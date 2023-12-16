namespace TableReservationsApp.Models
{
    public class Reservation
    {
        private static int _counter = 1000;

        private readonly Table _table;

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        static Reservation()
        {
            _counter = 1000;
        }

        public Reservation(Table table, DateTime date, string name)
        {
            this._table = table;
            Date = date;
            Name = name;

            Id = ++_counter;
        }
    }
}
