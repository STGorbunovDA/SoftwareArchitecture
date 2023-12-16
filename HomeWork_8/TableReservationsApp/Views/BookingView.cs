using System.Xml.Linq;
using TableReservationsApp.Interfeces;
using TableReservationsApp.Models;

namespace TableReservationsApp.Views
{
    public class BookingView : IView
    {
        private readonly List<IViewObserver> _observers = new();

        public void RegisterObserver(IViewObserver observer)
        {
            _observers.Add(observer);
        }

        public void ShowReservationTableResult(int reservationNumber)
        {
            if (reservationNumber > 0) Console.WriteLine($"Столик успешно забронирован. Номер вашей брони: {reservationNumber}\n");
            else Console.WriteLine("Не удалось забронировать столик. Повторите попытку позже.\n");
        }

        public void RegisterTable(DateTime orderDate, int numberTable, string name)
        {
            foreach (var observer in _observers)
                observer.OnRegisterTable(orderDate, numberTable, name);
        }

        public void ShowTables(IList<Table> tables)
        {
            foreach (var table in tables)
                Console.WriteLine(table);
        }

        public void ChangeRegisterTable(int idRegisterTable, DateTime newOrderDate, int newNumberTable, string newName)
        {
            foreach (var observer in _observers)
                observer.ChangeReservationTable(idRegisterTable, newOrderDate, newNumberTable, newName);
        }
    }
}
