using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Core.Interfaces;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly CoachServicesContext _coachServicesContext;

        public HorarioRepository(CoachServicesContext coachServicesContext)
        {
            _coachServicesContext = coachServicesContext;
        }

        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await _coachServicesContext.Horario.ToListAsync();
        }

        public async Task<Horario> GetById(int id)
        {
            return await _coachServicesContext
                .Horario
                .Where(x => x.IdHorario == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Horario horario)
        {
            await _coachServicesContext.Horario.AddAsync(horario);
            int rows = await _coachServicesContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Horario horario)
        {
            _coachServicesContext.Horario.Update(horario);
            int rows = await _coachServicesContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
