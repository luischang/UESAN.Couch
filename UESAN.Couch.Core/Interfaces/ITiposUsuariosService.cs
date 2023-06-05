using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ITiposUsuariosService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TiposUsuarioDescriptionDTO>> GetAll();
        Task<TiposUsuarioDTOS> GetById(int id);
        Task<bool> Insert(TiposUsuarioInsertDTO tipoUsuarioInsertDTO);
        Task<bool> Update(TiposUsuarioDTOS tipoUsuarioDTO);
    }
}