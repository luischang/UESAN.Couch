using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<TiposUsuario> Create(TiposUsuario tipoUsuario);
        Task Delete(int id);
        Task<IEnumerable<TiposUsuario>> GetAll();
        Task<TiposUsuario> GetById(int id);
        Task Update(TiposUsuario tipoUsuario);
    }
}