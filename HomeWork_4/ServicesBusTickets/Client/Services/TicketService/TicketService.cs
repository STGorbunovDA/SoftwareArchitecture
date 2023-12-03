using System.Net.Http.Json;

namespace ServicesBusTickets.Client.Services.TicketService
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _http;

        public TicketService(HttpClient http) => _http = http;

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public async Task GetTicket()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Ticket>>>("api/ticket");
            if (result != null && result.Data != null)
                Tickets = result.Data;
        }

        public async Task<ServiceResponse<Ticket>> GetTicket(int ticketId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Ticket>>($"api/ticket/{ticketId}");
            return result;
        }
    }
}
