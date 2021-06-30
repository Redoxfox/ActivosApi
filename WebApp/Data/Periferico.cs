using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class Periferico
    {
        public Periferico()
        {
            UsuarioPerifericos = new HashSet<UsuarioPeriferico>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Serial { get; set; }
        public string Asinado { get; set; }
        public string Estado { get; set; }
        public int? IdTipo { get; set; }

        public virtual TipoActivoTi IdTipoNavigation { get; set; }
        public virtual ICollection<UsuarioPeriferico> UsuarioPerifericos { get; set; }
    }
}
