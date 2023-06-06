using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface IPagoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Pago>> GetAll();
        Task<IEnumerable<Pago>> GetAllByEmprendedor(int idEmprendedor);
        Task<Pago> GetById(int id);
        Task<bool> Insert(Pago pago);
        Task<bool> Update(Pago pago);
    }
}