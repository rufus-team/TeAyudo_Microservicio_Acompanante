namespace Domain.Entities
{
    public class Horarios
    {
        public int AcompananteID { get; set; }
        public int Lunes { get; set; }
        public int Martes { get; set; }
        public int Miercoles { get; set; }
        public int Jueves { get; set; }
        public int Viernes { get; set; }
        public int Sabado { get; set; }
        public int Domingo { get; set; }
        public Acompanante Acompanante { get; set; }
    }
}
