using ClinicService.Services.ClientServices;
using ClinicService.Services.PetServices;
using ClinicService.Shared.Dto;
using ClinicService.Shared.Entity;
using ClinicService.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IClientRepository _clientRepository;
        private IPetRepository _petRepository;

        public PetController(IClientRepository clientRepository, IPetRepository petRepository)
        {
            _clientRepository = clientRepository;
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<Pet>>> Create([FromBody] Pet pet)
        {
            var clientCheck = await _clientRepository.GetById(pet.ClientId);
            
            if(clientCheck.Data is null)
                return BadRequest("Необходимо зарегистрировать Владельца животного");

            var result = await _petRepository.Create(pet);
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<ActionResult<ServiceResponse<Pet>>> Update([FromBody] Pet pet)
        {
            var petCheck = await _petRepository.GetById(pet.PetId);
            if (petCheck.Data is null)
                return BadRequest("Необходимо зарегистрировать Животное");

            var client = await _clientRepository.GetById(pet.ClientId);
            if (client.Data is null)
                return BadRequest("Необходимо зарегистрировать Владельца животного");

            var result = await _petRepository.Update(pet);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<int>>> Delete([FromQuery] int petId)
        {
            var result = await _petRepository.Delete(petId);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<ServiceResponse<IList<Pet>>>> GetAll()
        {
            var result = await _petRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("get/{clientId}")]
        public async Task<ActionResult<ServiceResponse<Pet>>> GetById([FromRoute] int petId)
        {
            var result = await _petRepository.GetById(petId);
            return Ok(result);
        }
    }
}
