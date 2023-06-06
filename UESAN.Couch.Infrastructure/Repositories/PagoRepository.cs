using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly CoachServicesContext _context;
        public PagoRepository(CoachServicesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pago>> GetPagos()
        {
            var pagos = await _context.Pago.ToListAsync();
            return pagos;
        }
        public async Task<Pago> GetPago(int id)
        {
            var pago = await _context.Pago.FindAsync(id);
            return pago;
        }
        public async Task<Pago> AddPago(Pago pago)
        {
            _context.Pago.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }
        public async Task<Pago> UpdatePago(Pago pago)
        {
            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return pago;
        }
        public async Task<Pago> DeletePago(int id)
        {
            var pago = await _context.Pago.FindAsync(id);
            _context.Pago.Remove(pago);
            await _context.SaveChangesAsync();
            return pago;
        }
    }
}
