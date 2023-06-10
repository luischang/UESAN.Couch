using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IPagoServices
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<PagoEmprendedorDTO>> GetAll();
        Task<PagoEmprendedorDTO> GetById(int id);
        Task<bool> Insert(PagoInDTO pagoInUpDTO);
        Task<bool> Update(PagoUpDTO pagoInUpDTO);
    }
}