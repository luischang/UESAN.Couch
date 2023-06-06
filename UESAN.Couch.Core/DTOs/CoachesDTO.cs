using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Couch.Core.DTOs
{
    public class CoachesDTO
    {
        public int IdCoach { get; set; }

        public int? IdPersona { get; set; }

        public decimal? TarifaHora { get; set; }

        public bool? IsActive { get; set; }
    }

    public class CoachesDatosDTO
    {
        public int IdCoach { get; set; }

        public int? IdPersona { get; set; }

        public decimal? TarifaHora { get; set; }
    }

    public class CoachesUsuariosDTO
    {
        public int IdCoach { get; set; }

        public int? IdPersona { get; set; }

        public decimal? TarifaHora { get; set; }

        public bool? IsActive { get; set; }

        public UsuariosDatosDTO Usuarios { get; set; }
    }

    public class CoachesInsertDTO
    {
        public int? IdPersona { get; set; }
        public decimal? TarifaHora { get; set; }
        public bool? IsActive { get; set; }
    }

    public class CoachesUpdateDTO
    {
        public int IdCoach { get; set; }
        public int? IdPersona { get; set; }
        public decimal? TarifaHora { get; set; }
        public bool? IsActive { get; set; }
    }
}
