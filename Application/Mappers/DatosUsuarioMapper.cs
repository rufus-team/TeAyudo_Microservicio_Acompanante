using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class DatosUsuarioMapper
    {
        public AcompananteResponse SetDatosAt(UsuarioResponse DatosAT, AcompananteResponse Acompanante)
        {
            Acompanante.FotoPerfil = DatosAT.FotoPerfil;
            Acompanante.UsuarioNombre = DatosAT.UsuarioNombre;
            Acompanante.Contraseña = DatosAT.Contraseña;
            Acompanante.Email = DatosAT.Email;
            Acompanante.Telefono = DatosAT.Telefono;
            Acompanante.Nombres = DatosAT.Nombres;
            Acompanante.Apellido = DatosAT.Apellido;
            Acompanante.FechaNacimiento = DatosAT.FechaNacimiento;
            return Acompanante;
        }
    }
}
