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
    public class TipoPlanRepository : ITipoPlanRepository
    {
        private readonly CoachServicesContext _context;

        public TipoPlanRepository(CoachServicesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoPlan>> GetAll()
        {
            return await _context.TipoPlan.ToListAsync();
        }

        public async Task<TipoPlan> GetById(int id)
        {
            return await _context.TipoPlan.Where(x => x.IdPlan == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(TipoPlan tipoPlan)
        {
            await _context.TipoPlan.AddAsync(tipoPlan);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(TipoPlan tipoPlan)
        {
            _context.TipoPlan.Update(tipoPlan);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
