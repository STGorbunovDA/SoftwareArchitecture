using ClinicService.Shared;

namespace ClinicService.Services.Base
{
    public interface IRepository<T, TId> where T : class
    {
        Task<ServiceResponse<IList<T>>> GetAll();
        Task<ServiceResponse<T>> GetById(TId id);
        Task<ServiceResponse<T>> Create(T item);
        Task<ServiceResponse<T>> Update(T item);
        Task<ServiceResponse<TId>> Delete(TId id);
    }
}
