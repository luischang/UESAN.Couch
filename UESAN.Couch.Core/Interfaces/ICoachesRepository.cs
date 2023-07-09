using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface ICoachesRepository
    {
        Task<bool> Delete(int id);
        Task<Usuarios> SignIn(string email, string password);
        Task<bool> IsEmailRegistered(string correoElectronico);
        Task<IEnumerable<Coaches>> GetAll();
        Task<IEnumerable<Coaches>> GetByIdServicio(int IdServicio);
        Task<Coaches> GetById(int id);
        Task<bool> Insert(Coaches coaches);
        Task<bool> Update(Coaches coaches);
       
    }
}