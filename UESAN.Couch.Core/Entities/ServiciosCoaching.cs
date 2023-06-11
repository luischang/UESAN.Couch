using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class ServiciosCoaching
{
    public int IdServicio { get; set; }

    public string? NombreServicio { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<DetalleCoachServicio> DetalleCoachServicio { get; set; } = new List<DetalleCoachServicio>();
}
