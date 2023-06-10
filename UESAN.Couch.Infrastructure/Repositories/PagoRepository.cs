using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.Interfaces;
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
        //la tabla pago esta relacionada con la tabla emprendedor y la tabla detalle pago esta relacionada con la tabla pago
        public async Task<IEnumerable<Pago>> GetAll()
        {
            return await _context.Pago
                .Include(x=> x.IdEmprendedorNavigation)
                .ToListAsync();
            
        }
        public async Task<Pago> GetById(int id)
        {
            return await _context.Pago
                .Where(x => x.IdEmprendedor == id)
                .Include(z => z.IdEmprendedorNavigation)
                .FirstOrDefaultAsync();
            
        }
       
        public async Task<bool> Insert(Pago pago)
        {
            await _context.Pago.AddAsync(pago);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<bool> Update(Pago pago)
        {
            _context.Pago.Update(pago);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<bool> Delete(int id)
        {
            var pago = await _context.Pago.Where(x => x.IdPago == id).FirstOrDefaultAsync();
           
            _context.Pago.Remove(pago);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
            
        }

    }
}
