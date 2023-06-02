﻿using System;
using System.Collections.Generic;

namespace UESAN.Couch.Infrastructure.Data;

public partial class Usuarios
{
    public int IdPersona { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Genero { get; set; }

    public string? NroContacto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasena { get; set; }

    public bool? IsActive { get; set; }

    public int? IdTipo { get; set; }

    public virtual ICollection<Coaches> Coaches { get; set; } = new List<Coaches>();

    public virtual ICollection<Emprendadores> Emprendadores { get; set; } = new List<Emprendadores>();

    public virtual TiposUsuario? IdTipoNavigation { get; set; }
}