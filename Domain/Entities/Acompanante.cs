using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Acompanante
    {
        public int AcompananteID { get; set; }
        public int UsuarioID { get; set; }
        public Horarios Horarios { get; set; } 
    }
}
