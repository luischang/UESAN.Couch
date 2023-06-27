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
    public class CoachesRepository : ICoachesRepository
    {
        private readonly CoachServicesContext _context;

        public CoachesRepository(CoachServicesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coaches>> GetAll()
        {
            return await _context.Coaches.ToListAsync();
        }

        public async Task<Coaches> GetById(int id)
        {
            return await _context.Coaches.FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Coaches coaches)
        {
            await _context.Coaches.AddAsync(coaches);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Coaches coaches)
        {
            _context.Coaches.Update(coaches);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var coaches = await _context.Coaches.Where(x => x.IdCoach == id).FirstOrDefaultAsync();

            if (coaches == null)
                return false;

            coaches.IsActive = false;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}