using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class Consumible
    {
        public Consumible()
        {
            UsuarioConsumibles = new HashSet<UsuarioConsumible>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Asignado { get; set; }
        public string Estado { get; set; }
        public int? IdTipo { get; set; }

        public virtual TipoActivoTi IdTipoNavigation { get; set; }
        public virtual ICollection<UsuarioConsumible> UsuarioConsumibles { get; set; }
    }
}
