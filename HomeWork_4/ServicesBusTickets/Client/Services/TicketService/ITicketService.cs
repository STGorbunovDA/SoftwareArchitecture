namespace ServicesBusTickets.Client.Services.TicketService
{
    public interface ITicketService
    {
        List<Ticket> Tickets { get; set; }
        Task GetTicket();
        Task<ServiceResponse<Ticket>> GetTicket(int ticketId);
    }
}
