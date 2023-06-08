using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> RegisterEmprendedor(UserAuthRequestDTO UsuariosDTO);
        Task<bool> RegisterCoach(UserAuthRequestDTO UsuariosDTO);
        Task<UserAuthResponseDTO> Validate(string email, string password);
    }
}