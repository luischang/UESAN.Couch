using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IDetalleCoachServicioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleCoachServicio>> GetAll();
        Task<IEnumerable<DetalleCoachServicio>> GetAllByCouch(int idCoach);
        Task<IEnumerable<DetalleCoachServicio>> GetAllByServicio(int idServicio);
        Task<DetalleCoachServicio> GetById(int id);
        Task<bool> Insert(DetalleCoachServicio detalleCoachServicio);
        Task<bool> Update(DetalleCoachServicio detalleCoachServicio);
    }
}