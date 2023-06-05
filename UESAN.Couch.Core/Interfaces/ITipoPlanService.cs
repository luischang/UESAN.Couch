using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ITipoPlanService
    {
        Task<IEnumerable<TipoPlanDTO>> GetAll();
        Task<TipoPlanDTO> GetById(int id);
        Task<bool> Insert(TipoPlanInsertDTO tipoPlanInsertDTO);
        Task<bool> Update(TipoPlanUpdateDTO tipoPlanUpdateDTO);
    }
}