using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class DetalleCoachServicio
{
    public int IdDetCoachServicio { get; set; }

    public int? IdCoach { get; set; }

    public int? IdPlan { get; set; }

    public int? Multiplicador { get; set; }

    public int? IdServicio { get; set; }

    public int? IdHorario { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<DetallePago> DetallePago { get; set; } = new List<DetallePago>();

    public virtual Coaches? IdCoachNavigation { get; set; }

    public virtual Horario? IdHorarioNavigation { get; set; }

    public virtual TipoPlan? IdPlanNavigation { get; set; }

    public virtual ServiciosCoaching? IdServicioNavigation { get; set; }

}
