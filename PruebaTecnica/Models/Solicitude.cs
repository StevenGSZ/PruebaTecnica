using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models;

public partial class Solicitude
{
    public int IdSolicitud { get; set; }

    public string Name { get; set; } = null!;

    public string Departament { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Application { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime FinalDate { get; set; }

    public string Description { get; set; } = null!;

    public string? Estado { get; set; }
}
