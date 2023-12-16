using TableReservationsApp.Interfeces;

namespace TableReservationsApp.Presenters
{
    public class BookingPresenter : IViewObserver
    {

        private ITableService _tableService;
        private IView _view;

        public BookingPresenter(ITableService tableService, IView view)
        {
            _tableService = tableService;
            _view = view;
            _view.RegisterObserver(this);
        }

        private void UpdateUIReservationTableResult(int reservationNumber)
        {
            _view.ShowReservationTableResult(reservationNumber);
        }

        public void UpdateUILoadTables()
        {
            _view.ShowTables(_tableService.LoadTables());
        }


        public void OnRegisterTable(DateTime orderDate, int numberTable, string name)
        {
            try
            {
                int reservationNumber = _tableService.ReservationTable(orderDate, numberTable, name);
                UpdateUIReservationTableResult(reservationNumber);
            }
            catch (Exception e)
            {
                UpdateUIReservationTableResult(-1);
            }
        }

        public void ChangeReservationTable(int idRegisterTable, DateTime newDateTime, int numberTable, string newName)
        {
            try
            {
                int reservationNumber = _tableService.ChangeReservationTable(idRegisterTable, newDateTime, numberTable, newName);
                UpdateUIReservationTableResult(reservationNumber);
            }
            catch (Exception)
            {
                UpdateUIReservationTableResult(-1);
            }
        }
    }
}
