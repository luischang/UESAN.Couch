using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class Emprendadores
{
    public int IdEmprendedor { get; set; }

    public int? IdPersona { get; set; }

    public bool? IsActive { get; set; }

    public virtual Usuarios? IdPersonaNavigation { get; set; }

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
