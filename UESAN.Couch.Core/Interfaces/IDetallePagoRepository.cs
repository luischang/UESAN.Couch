using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IDetallePagoRepository
    {
        Task<IEnumerable<DetallePago>> GetAll();
        Task<IEnumerable<DetallePago>> GetAllByDetalleCoachServicio(int idDetCoachServ);
        Task<IEnumerable<DetallePago>> GetAllByPago(int idPago);
        Task<DetallePago> GetById(int id);
        Task<bool> Insert(DetallePago detallePago);
        Task<bool> Update(DetallePago detallePago);
    }
}