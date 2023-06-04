
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IServiciosCoachingRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ServiciosCoaching>> GetAll();
        Task<ServiciosCoaching> GetById(int id);
        Task<bool> Insert(ServiciosCoaching serviciosCoaching);
        Task<bool> Update(ServiciosCoaching serviciosCoaching);
    }
}