using AutoMapper;
using ClinicService.Shared;
using ClinicService.Shared.Dto;
using ClinicService.Shared.Entity;

namespace ClinicService.Services.ClientServices.Profiles
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
        }
    }
}
