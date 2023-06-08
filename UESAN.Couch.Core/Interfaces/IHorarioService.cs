using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IHorarioService
    {
        Task<IEnumerable<HorarioDTO>> GetAll();
        Task<HorarioDTO> GetById(int id);
        Task<bool> Insert(HorarioInsertDTO horarioInsertDTO);
        Task<bool> Update(HorarioUpdateDTO horarioUpdateDTO);
    }
}