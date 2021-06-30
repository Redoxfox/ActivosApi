using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class UsuarioActivo
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string Disponibilidad { get; set; }
        public int? IdActivo { get; set; }

        public virtual Activo IdActivoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
