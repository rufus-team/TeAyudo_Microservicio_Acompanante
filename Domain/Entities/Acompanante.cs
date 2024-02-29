namespace Domain.Entities
{
    public class Acompanante
    {
        public int AcompananteID { get; set; }
        public int UsuarioID { get; set; }
        public Horarios Horarios { get; set; }
        public string Descripcion { get; set; }
        public List<Tag> Tags { get; } = [];
    }
}
