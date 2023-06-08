using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IDetallePagoService
    {
        Task<IEnumerable<DetallePagoDTO>> GetAll();
        Task<IEnumerable<DetallePagoListDTO>> GetAllByDetCoachServ(int idDetCoachServ);
        Task<IEnumerable<DetallePagoListDTO>> GetAllByPago(int idPago);
        Task<DetallePagoDTO> GetById(int id);
        Task<bool> Insert(DetallePagoInsertDTO detallePagoInsertDTO);
        Task<bool> Update(DetallePagoUpdateDTO updateDTO);
    }
}