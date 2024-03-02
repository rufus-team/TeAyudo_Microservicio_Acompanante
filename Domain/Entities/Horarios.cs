namespace Domain.Entities
{
    public class Horarios
    {
        public int AcompananteID { get; set; }
        public Int16 Lunes { get; set; }
        public Int16 Martes { get; set; }
        public Int16 Miercoles { get; set; }
        public Int16 Jueves { get; set; }
        public Int16 Viernes { get; set; }
        public Int16 Sabado { get; set; }
        public Int16 Domingo { get; set; }
        public Acompanante Acompanante { get; set; }
    }
}
