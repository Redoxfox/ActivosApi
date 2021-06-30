using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class UsuarioPeriferico
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string Disponibilidad { get; set; }
        public int? IdPeriferico { get; set; }

        public virtual Periferico IdPerifericoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
