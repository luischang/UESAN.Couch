using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly CoachServicesContext _context;
        public TipoUsuarioRepository(CoachServicesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TiposUsuario>> GetAll()
        {
            return await _context.TiposUsuario.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<TiposUsuario> GetById(int id)
        {
            return await _context.TiposUsuario.Where(x => x.IdTipo == id).FirstOrDefaultAsync();

        }

        public async Task<bool> Insert(TiposUsuario tiposUsuario)
        {
            await _context.TiposUsuario.AddAsync(tiposUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(TiposUsuario tiposUsuario)
        {
            _context.TiposUsuario.Update(tiposUsuario);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findCategory = await _context.TiposUsuario.Where(x => x.IdTipo == id).FirstOrDefaultAsync();
            if (findCategory == null)
                return false;

            findCategory.IsActive = false;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
