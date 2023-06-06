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
    public class DetallePagoRepository : IDetallePagoRepository
    {
        private readonly CoachServicesContext _context;

        public DetallePagoRepository(CoachServicesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePago>> GetAll()
        {
            return await _context
                .DetallePago
                .ToListAsync();
        }

        public async Task<DetallePago> GetById(int id)
        {
            return await _context
                .DetallePago
                .Where(x => x.IdDetpago == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DetallePago>> GetAllByDetalleCoachServicio(int idDetCoachServ)
        {
            return await _context
                .DetallePago
                .Where(x => x.IdDetCoachServicio == idDetCoachServ)
                .Include(y => y.IdDetCoachServicioNavigation)
                .ThenInclude(z => z.IdCoachNavigation)
                .ThenInclude(m => m.IdPersonaNavigation)
                .ToListAsync();
        }

        public async Task<IEnumerable<DetallePago>> GetAllByPago(int idPago)
        {
            return await _context
                .DetallePago
                .Where(x => x.IdPago == idPago)
                .Include(y => y.IdPagoNavigation)
                .ThenInclude(z => z.IdEmprendedorNavigation)
                .ThenInclude(m => m.IdPersonaNavigation)
                .ToListAsync();
        }

        public async Task<bool> Insert(DetallePago detallePago)
        {
            await _context
                .DetallePago
                .AddAsync(detallePago);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(DetallePago detallePago)
        {
            _context.DetallePago.Update(detallePago);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
