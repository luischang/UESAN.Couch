using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class EmprendedoresRepository : IEmprendedoresRepository
    {
        private readonly CoachServicesContext _context;
        public EmprendedoresRepository(CoachServicesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Emprendadores>> GetAll()
        {
           
            var result = await _context.Emprendadores.Where(x => x.IsActive == true).ToListAsync();
                
            return result;
        }
        public async Task<Emprendadores> GetById(int id)
        {
            var result = await _context.Emprendadores.Where(x => x.IdEmprendedor == id).FirstOrDefaultAsync();
                
            return result;
        }
        public async Task<bool> Insert(Emprendadores emprendedores)
        {
            _context.Emprendadores.AddAsync(emprendedores);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
        public async Task<bool> Update(Emprendadores emprendedores)
        {
            _context.Emprendadores.Update(emprendedores);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var emprendedores = await _context.Emprendadores.Where(x => x.IdEmprendedor == id).FirstOrDefaultAsync();
            if (emprendedores == null)
                return false;
            emprendedores.IsActive = false;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }
    }
}
