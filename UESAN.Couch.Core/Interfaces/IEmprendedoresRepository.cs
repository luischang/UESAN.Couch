using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface IEmprendedoresRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Emprendadores>> GetAll();
        Task<Emprendadores> GetById(int id);
        Task<bool> Insert(Emprendadores emprendedores);
        Task<bool> Update(Emprendadores emprendedores);
    }
}