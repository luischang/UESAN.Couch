using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class TiposUsuario
{
    public int IdTipo { get; set; }

    public string? NombreTipo { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
