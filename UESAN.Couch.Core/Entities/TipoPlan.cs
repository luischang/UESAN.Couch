using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class TipoPlan
{
    public int IdPlan { get; set; }

    public string? NombrePlan { get; set; }

    public virtual ICollection<DetalleCoachServicio> DetalleCoachServicio { get; set; } = new List<DetalleCoachServicio>();
}
