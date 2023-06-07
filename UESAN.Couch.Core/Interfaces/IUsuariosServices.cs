using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> Register(UserAuthRequestDTO UsuariosDTO);
        Task<UserAuthResponseDTO> Validate(string email, string password);
    }
}