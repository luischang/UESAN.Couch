using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface ITipoPlanRepository
    {
        Task<IEnumerable<TipoPlan>> GetAll();
        Task<TipoPlan> GetById(int id);
        Task<bool> Insert(TipoPlan tipoPlan);
        Task<bool> Update(TipoPlan tipoPlan);
    }
}