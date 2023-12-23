using ClinicService.Services.Base;
using ClinicService.Shared;
using ClinicService.Shared.Entity;

namespace ClinicService.Services.ClientServices
{
    public interface IClientRepository : IRepository<Client, int> { }
}
