using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class DetallePago
{
    public int IdDetpago { get; set; }

    public int? IdPago { get; set; }

    public int? IdDetCoachServicio { get; set; }

    public int? NroSolicitudes { get; set; }

    public virtual DetalleCoachServicio? IdDetCoachServicioNavigation { get; set; }

    public virtual Pago? IdPagoNavigation { get; set; }
}
