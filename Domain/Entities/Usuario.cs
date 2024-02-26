using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contrasena { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsAcompanante { get; set; }
        public Acompanante Acompanante { get; set; }
    }
}
