using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IDetalleCoachService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleCouchServicioDTO>> GetAll();
        Task<IEnumerable<DetalleCouchServicioListDTO>> GetAllByCouch(int idCoach);
        Task<IEnumerable<DetalleCouchServicioListDTO>> GetAllByServicio(int idServicio);
        Task<DetalleCouchServicioDTO> GetById(int id);
        Task<bool> Insert(DetalleCouchServicioInsertDTO detcoachservsDTO);
        Task<bool> Update(DetalleCouchServicioDTO detalleCouchServicioDTO);
    }
}