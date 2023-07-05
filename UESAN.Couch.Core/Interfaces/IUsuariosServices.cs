using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Services
{
    public interface IUsuariosServices
    {
        Task<bool> Register(UserAuthRequestDTO UsuariosDTO);
        Task<int> RegisterCoach(UserAuthRequestCoachDTO UsuariosDTO);
        Task<UserAuthResponseDTO> Validate(string email, string password);
    }
}