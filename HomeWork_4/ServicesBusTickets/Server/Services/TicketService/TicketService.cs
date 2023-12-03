namespace ServicesBusTickets.Server.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly DataContext _context;

        public TicketService(DataContext context) => _context = context;

        public async Task<ServiceResponse<Ticket>> GetTicketAsync(int productId)
        {
            var response = new ServiceResponse<Ticket>();
            var product = await _context.Tickets.FindAsync(productId);
            if (product == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this ticket does not exist.";
            }
            else response.Data = product;

            return response;
        }

        public async Task<ServiceResponse<List<Ticket>>> GetTicketsAsync()
        {
            var response = new ServiceResponse<List<Ticket>>
            {
                Data = await _context.Tickets.ToListAsync()
            };

            return response;
        }
    }
}
