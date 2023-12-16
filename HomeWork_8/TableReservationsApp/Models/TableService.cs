using System.Xml.Linq;
using TableReservationsApp.Interfeces;

namespace TableReservationsApp.Models
{
    public class TableService : ITableService
    {
        private IList<Table>? _tables;

        public int ChangeReservationTable(int idRegisterTable, DateTime newOrderDate, int newNumberTable, string newName)
        {
            if (_tables is null) throw new Exception("Столики заняты");

            foreach (var table in _tables)
            {
                if (table.Reservations.Count > 0)
                {
                    foreach (var reservation in table.Reservations)
                    {
                        if(reservation.Id == idRegisterTable)
                        {
                            table.Reservations.Clear();
                            Reservation newReservation = new(table, newOrderDate, newName);
                            table.Reservations.Add(newReservation);
                            return newReservation.Id;
                        }
                    }
                }
            }
            throw new Exception("Некорректный номер столика");
        }

        public IList<Table> LoadTables()
        {
            _tables ??= new List<Table>()
                {
                    new(),
                    new(),
                    new(),
                    new(),
                };

            return _tables;
        }

        public int ReservationTable(DateTime reservationDate, int numberTable, string name)
        {
            if (_tables is null) throw new Exception("Столики заняты");
            foreach (var table in _tables)
                if (table.Number.Equals(numberTable))
                {
                    Reservation reservation = new(table, reservationDate, name);
                    table.Reservations.Add(reservation);
                    return reservation.Id;
                }


            throw new Exception("Некорректный номер столика");
        }
    }
}
