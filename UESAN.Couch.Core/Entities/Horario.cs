using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class Horario
{
    public int IdHorario { get; set; }

    public DateTime? HoraInicio { get; set; }

    public DateTime? HoraFin { get; set; }

    public virtual ICollection<DetalleCoachServicio> DetalleCoachServicio { get; set; } = new List<DetalleCoachServicio>();
}
