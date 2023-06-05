using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IHorarioRepository
    {
        Task<IEnumerable<Horario>> GetAll();
        Task<Horario> GetById(int id);
        Task<bool> Insert(Horario horario);
        Task<bool> Update(Horario horario);
    }
}