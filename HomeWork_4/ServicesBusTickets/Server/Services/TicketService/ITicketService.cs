namespace ServicesBusTickets.Server.Services.TicketService
{
    public interface ITicketService
    {
        Task<ServiceResponse<List<Ticket>>> GetTicketsAsync();
        Task<ServiceResponse<Ticket>> GetTicketAsync(int productId);
    }
}
