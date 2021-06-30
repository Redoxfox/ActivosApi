using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class UsuarioConsumible
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string Disponibilidad { get; set; }
        public int? IdConsumible { get; set; }

        public virtual Consumible IdConsumibleNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
