using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IDetalleCoachService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleCouchServicioDTO>> GetAll();
        Task<IEnumerable<DetalleCouchServicioListDTO>> GetAllByServicio(int idServicio);
        Task<DetalleCouchServicioDTOo> GetById(int id);
        Task<int> Insert(DetalleCouchServicioInsertDTO detcoachservsDTO);
        Task<bool> Update(DetalleCouchServicioDTO detalleCouchServicioDTO);
    }
}