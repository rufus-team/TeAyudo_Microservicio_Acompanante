namespace Application.Model.Responses
{
    public class UsuarioResponse
    {
        public int UsuarioID { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string UsuarioNombre { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        //public int AcompananteID { get; set; }
    }
}
