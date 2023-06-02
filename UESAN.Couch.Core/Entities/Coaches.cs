using System;
using System.Collections.Generic;


namespace UESAN.Couch.Infrastructure.Data;

public partial class Coaches
{
    public int IdCoach { get; set; }

    public int? IdPersona { get; set; }

    public decimal? TarifaHora { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<DetalleCoachServicio> DetalleCoachServicio { get; set; } = new List<DetalleCoachServicio>();

    public virtual Usuarios? IdPersonaNavigation { get; set; }
}
