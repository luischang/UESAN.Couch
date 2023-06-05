using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TiposUsuario>> GetAll();
        Task<TiposUsuario> GetById(int id);
        Task<bool> Insert(TiposUsuario tiposUsuario);
        Task<bool> Update(TiposUsuario tiposUsuario);
    }
}