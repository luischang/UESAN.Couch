using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class Pago
{
    public int IdPago { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int? IdEmprendedor { get; set; }

    public decimal? TotalPago { get; set; }

    public virtual ICollection<DetallePago> DetallePago { get; set; } = new List<DetallePago>();

    public virtual Emprendadores? IdEmprendedorNavigation { get; set; }
}
