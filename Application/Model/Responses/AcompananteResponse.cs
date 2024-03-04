﻿namespace Application.Model.Responses
{
    public class AcompananteResponse
    {
        public int AcompananteID { get; set; }
        public int UsuarioID { get; set; }
        public string Descripcion { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
