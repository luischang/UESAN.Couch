using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Couch.Core.DTOs
{
    public class HorarioDTO
    {
        public int IdHorario { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; }
    }

    public class HorarioInsertDTO
    {
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; }
    }

    public class HorarioUpdateDTO
    {
        public int IdHorario { get; set; }
        public DateTime? HoraInicio { get; set; }
        public DateTime? HoraFin { get; set; }
    }
}
