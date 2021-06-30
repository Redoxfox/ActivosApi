using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioActivos = new HashSet<UsuarioActivo>();
            UsuarioConsumibles = new HashSet<UsuarioConsumible>();
            UsuarioPerifericos = new HashSet<UsuarioPeriferico>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Usuario1 { get; set; }
        public string Dependencia { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<UsuarioActivo> UsuarioActivos { get; set; }
        public virtual ICollection<UsuarioConsumible> UsuarioConsumibles { get; set; }
        public virtual ICollection<UsuarioPeriferico> UsuarioPerifericos { get; set; }
    }
}
