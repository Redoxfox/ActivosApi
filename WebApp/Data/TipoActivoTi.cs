using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class TipoActivoTi
    {
        public TipoActivoTi()
        {
            Activos = new HashSet<Activo>();
            Consumibles = new HashSet<Consumible>();
            Perifericos = new HashSet<Periferico>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Activo> Activos { get; set; }
        public virtual ICollection<Consumible> Consumibles { get; set; }
        public virtual ICollection<Periferico> Perifericos { get; set; }
    }
}
