using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UESAN.Couch.Core.DTOs
{
    public class DetalleCouchServicioDTO
    {
        public int IdDetCoachServicio { get; set; }

        public int? IdCoach { get; set; }

        public int? IdPlan { get; set; }

        public int? Multiplicador { get; set; }

        public int? IdServicio { get; set; }

        public int? IdHorario { get; set; }
        public bool? IsActive { get; set; }
    }

    public class DetalleCouchServicioDTOo
    {
        public int IdDetCoachServicio { get; set; }

        public int? IdCoach { get; set; }

        public int? IdPlan { get; set; }

        public int? Multiplicador { get; set; }

        public int? IdServicio { get; set; }

        public int? IdHorario { get; set; }

        public bool? IsActive { get; set; }

    }

    public class DetalleCouchServicioListDTO
    {
        public int IdDetCoachServicio { get; set; }
        public CoachesUsuariosDTO Coaches { get; set; }
        public ServiciosCoachingDescriptionDTO ServiciosCoaching { get; set; }
    }

    public class DetalleCouchServicioInsertDTO
    {

        public int? IdCoach { get; set; }

        public int? IdPlan { get; set; }

        public int? Multiplicador { get; set; }

        public int? IdServicio { get; set; }

        public int? IdHorario { get; set; }

        public bool? IsActive { get; set; }
    }
}
