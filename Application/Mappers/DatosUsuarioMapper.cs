using Application.Model.Responses;

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
