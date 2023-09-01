using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Tipo { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? ObDepartamento { get; set; }
}
