using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public interface IPagoRepository
    {
        Task<Pago> AddPago(Pago pago);
        Task<Pago> DeletePago(int id);
        Task<Pago> GetPago(int id);
        Task<IEnumerable<Pago>> GetPagos();
        Task<Pago> UpdatePago(Pago pago);
    }
}