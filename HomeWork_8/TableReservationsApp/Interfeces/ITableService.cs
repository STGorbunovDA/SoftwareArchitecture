using TableReservationsApp.Models;

namespace TableReservationsApp.Interfeces
{
    public interface ITableService
    {
        IList<Table> LoadTables();

        int ReservationTable(DateTime reservationDate, int numberTable, string name);

        int ChangeReservationTable(int idRegisterTable, DateTime newOrderDate, int newNumberTable, string newName);
    }
}
