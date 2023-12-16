using TableReservationsApp.Interfeces;
using TableReservationsApp.Models;
using TableReservationsApp.Presenters;
using TableReservationsApp.Views;

namespace TableReservationsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITableService tableService = new TableService();
            IView view = new BookingView();
            BookingPresenter bookingPresenter = new(tableService, view);
            bookingPresenter.UpdateUILoadTables();

            view.RegisterTable(new DateTime(2023, 12, 16), 2, "Вася");

            view.ChangeRegisterTable(1003, new DateTime(2023, 12, 16), 3, "Вася");
        }
    }
}
