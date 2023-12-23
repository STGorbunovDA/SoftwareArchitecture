using ClinicService.Services.Base;
using ClinicService.Shared.Entity;

namespace ClinicService.Services.PetServices
{
    public interface IPetRepository : IRepository<Pet, int> { }
}
