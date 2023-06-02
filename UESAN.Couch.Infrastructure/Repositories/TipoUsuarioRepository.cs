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
            return await _context.TiposUsuario.ToListAsync();
        }
        public async Task<TiposUsuario> GetById(int id)
        {
            return await _context.TiposUsuario.FindAsync(id);
        }
        public async Task<TiposUsuario> Create(TiposUsuario tipoUsuario)
        {
            _context.TiposUsuario.Add(tipoUsuario);
            await _context.SaveChangesAsync();
            return tipoUsuario;
        }
        public async Task Update(TiposUsuario tipoUsuario)
        {
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var tipoUsuarioToDelete = await _context.TiposUsuario.FindAsync(id);
            _context.TiposUsuario.Remove(tipoUsuarioToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
