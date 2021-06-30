using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class Activo
    {
        public Activo()
        {
            UsuarioActivos = new HashSet<UsuarioActivo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public int? NroActivo { get; set; }
        public string Procesador { get; set; }
        public string Disco { get; set; }
        public string Color { get; set; }
        public string NombreEquipo { get; set; }
        public string Asignado { get; set; }
        public string Estado { get; set; }
        public int? IdTipo { get; set; }

        public virtual TipoActivoTi IdTipoNavigation { get; set; }
        public virtual ICollection<UsuarioActivo> UsuarioActivos { get; set; }
    }
}
