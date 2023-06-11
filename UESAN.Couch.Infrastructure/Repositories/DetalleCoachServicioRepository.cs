using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class DetalleCoachServicioRepository : IDetalleCoachServicioRepository
    {
        private readonly CoachServicesContext _context;

        public DetalleCoachServicioRepository(CoachServicesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleCoachServicio>> GetAll()
        {
            return await _context.DetalleCoachServicio.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<DetalleCoachServicio> GetById(int id)
        {
            return await _context
                        .DetalleCoachServicio
                        .Where(x => x.IdDetCoachServicio == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DetalleCoachServicio>> GetAllByServicio(int idServicio)
        {
            return await _context.
                DetalleCoachServicio.
                Where(x => x.IdServicio == idServicio)
                .Include(y => y.IdServicioNavigation)
                .Include(z => z.IdCoachNavigation)
                .ThenInclude(w => w.IdPersonaNavigation)
                .ToListAsync();
        }


        public async Task<bool> Insert(DetalleCoachServicio detalleCoachServicio)
        {
            await _context.DetalleCoachServicio.AddAsync(detalleCoachServicio);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(DetalleCoachServicio detalleCoachServicio)
        {
            _context.DetalleCoachServicio.Update(detalleCoachServicio);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findDetalleCoachServicio = await _context.DetalleCoachServicio
                .Where(x => x.IdDetCoachServicio == id)
                .FirstOrDefaultAsync();
            if (findDetalleCoachServicio == null)
                return false;

            findDetalleCoachServicio.IsActive = false;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
