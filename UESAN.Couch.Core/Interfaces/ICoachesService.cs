using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ICoachesService
    {
        Task<IEnumerable<CoachesDTO>> GetAll();
        Task<CoachesDTO> GetById(int id);
        Task<bool> Insert(CoachesInsertDTO insertDTO);
        Task<bool> Update(CoachesUpdateDTO updateDTO);
    }
}