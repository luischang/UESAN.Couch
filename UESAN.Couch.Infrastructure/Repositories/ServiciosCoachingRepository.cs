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
    public class ServiciosCoachingRepository : IServiciosCoachingRepository
    {
        private readonly CoachServicesContext _context;

        public ServiciosCoachingRepository(CoachServicesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiciosCoaching>> GetAll()
        {
            return await _context
                         .ServiciosCoaching
                         .ToListAsync();
        }

        public async Task<ServiciosCoaching> GetById(int id)
        {
            return await _context
                        .ServiciosCoaching
                        .Where(x => x.IdServicio == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ServiciosCoaching serviciosCoaching)
        {
            await _context.ServiciosCoaching.AddAsync(serviciosCoaching);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(ServiciosCoaching serviciosCoaching)
        {
            _context.ServiciosCoaching.Update(serviciosCoaching);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findServiciosCoaching = await _context
                                .ServiciosCoaching
                                .Where(x => x.IdServicio == id)
                                .FirstOrDefaultAsync();
            if (findServiciosCoaching == null)
                return false;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
