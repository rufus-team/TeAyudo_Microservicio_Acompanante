namespace Domain.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Nombre { get; set; }
        public List<Acompanante> Acompanantes { get; } = [];
    }
}
