using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ICoachesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Coaches>> GetAll();
        Task<Coaches> GetById(int id);
        Task<bool> Insert(Coaches coaches);
        Task<bool> Update(Coaches coaches);
    }
}