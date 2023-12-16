namespace TableReservationsApp.Interfeces
{
    public interface IViewObserver
    {
        void OnRegisterTable(DateTime orderDate, int numberTable, string name);
        void ChangeReservationTable(int idRegisterTable, DateTime newDateTime, int numberTable, string newName);
    }
}
