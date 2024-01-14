using Microsoft.AspNetCore.Mvc;
using ClinicService.Services.ClientServices;
using ClinicService.Shared;
using ClinicService.Shared.Entity;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost("create", Name = "ClientCreate")]
        public async Task<ActionResult<ServiceResponse<Client>>> Create([FromBody] Client client)
        {
            var result = await _clientRepository.Create(client);
            return Ok(result);
        }

        [HttpPut("edit", Name = "ClientUpdate")]
        public async Task<ActionResult<ServiceResponse<Client>>> Update([FromBody] Client client)
        {
            var clientCheck = await _clientRepository.GetById(client.ClientId);
            if (clientCheck.Data is null)
                return BadRequest("Необходимо зарегистрировать Владельца животного");
            var result = await _clientRepository.Update(client);
            return Ok(result);
        }


        [HttpDelete("delete", Name = "ClientDelete")]
        public async Task<ActionResult<ServiceResponse<int>>> Delete([FromQuery] int clientId)
        {
            var result = await _clientRepository.Delete(clientId);
            return Ok(result);
        }

        [HttpGet("get-all", Name = "ClientGetAll")]
        public async Task<ActionResult<ServiceResponse<IList<Client>>>> GetAll()
        {
            var result = await _clientRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("get/{clientId}", Name = "ClientGetById")]
        public async Task<ActionResult<ServiceResponse<Client>>> GetById([FromRoute] int clientId)
        {
            var result = await _clientRepository.GetById(clientId);
            return Ok(result);
        }

    }
}
