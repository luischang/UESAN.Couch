using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.DTOs
{
    public class CoachesDTO
    {
        public int IdCoach { get; set; }

        public int? IdPersona { get; set; }

        public decimal? TarifaHora { get; set; }

        public bool? IsActive { get; set; }
        public int IdServicio { get; set; }
    }
    public class CoachesDecripDTO
    {
        public int IdCoach { get; set; }
        public UserAuthRequestDTO IdPersonaNavigation { get; set; }

        public decimal? TarifaHora { get; set; }

        public bool? IsActive { get; set; }
        public int IdServicio { get; set; }
    }
    public class CoachesServiceDTO
    {
        public int IdCoach { get; set; }
        public UsuariosCoachesServiceDTO IdPersonaNavigation { get; set; }

        public ServiciosCoachingInsertDTO IdServicioNavigation { get; set; }
        public decimal? TarifaHora { get; set; }
        public int IdServicio { get; set; }

    }
    public class CoachesDatosDTO
    {
        public int IdCoach { get; set; }

        public int? IdPersona { get; set; }

        public decimal? TarifaHora { get; set; }
        public int IdServicio { get; set; }
    }

    public class CoachesUsuariosDTO
    {

        public decimal? TarifaHora { get; set; }


        public UsuariosDetCoachServiceDTO Usuarios { get; set; }
        public int IdServicio { get; set; }
    }

    public class CoachesInsertDTO
    {
        public int? IdPersona { get; set; }
        public decimal? TarifaHora { get; set; }
        public bool? IsActive { get; set; }
        public int IdServicio { get; set; }
    }

    public class CoachesUpdateDTO
    {
        public int IdCoach { get; set; }
        public int? IdPersona { get; set; }
        public decimal? TarifaHora { get; set; }
        public bool? IsActive { get; set; }
        public int IdServicio { get; set; }
    }
}