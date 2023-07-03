using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ICoachesService
    {
        Task<IEnumerable<CoachesDecripDTO>> GetAll();
        Task<CoachesServiceDTO> GetByIdServicio(int idServicio);
        Task<CoachesDecripDTO> GetById(int id);
        Task<bool> Insert(CoachesDTO insertDTO);
        Task<bool> Update(CoachesUpdateDTO updateDTO);
        Task<UserAuthResponseDTO> Validate(string email, string password);
        Task<bool> Delete(int id);
    }
}