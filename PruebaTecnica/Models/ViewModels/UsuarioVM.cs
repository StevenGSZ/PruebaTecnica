using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaTecnica.Models.ViewModels
{
    public class UsuarioVM
    {
        public Usuario obUsuario { get; set; }

        public List<SelectListItem> obListaDepartamento { get; set; }
    }
}
