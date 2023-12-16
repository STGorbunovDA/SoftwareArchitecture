using TableReservationsApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TableReservationsApp.Interfeces
{
    public interface IView
    {
        void ShowTables(IList<Table> tables);

        void ShowReservationTableResult(int reservationNumber);

        void RegisterObserver(IViewObserver observer);

        void RegisterTable(DateTime orderDate, int numberTable, string name);
        void ChangeRegisterTable(int idRegisterTable,DateTime newOrderDate, int newNumberTable,string newName);
    }
}
