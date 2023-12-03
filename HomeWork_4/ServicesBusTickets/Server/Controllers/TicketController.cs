using Microsoft.AspNetCore.Mvc;

namespace ServicesBusTickets.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService) => _ticketService = ticketService;

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Ticket>>>> GetProducts()
        {
            var result = await _ticketService.GetTicketsAsync();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Ticket>>> GetProduct(int productId)
        {
            var result = await _ticketService.GetTicketAsync(productId);
            return Ok(result);
        }
    }
}
