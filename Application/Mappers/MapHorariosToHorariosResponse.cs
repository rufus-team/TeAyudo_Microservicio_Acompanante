using Application.Model.Responses;
using Domain.Entities;

namespace Application.Mappers
{
    public class MapHorariosToHorariosResponse
    {
        public HorariosResponse HorarioToHorariosResponse(Horarios Horarios)
        {
            return new HorariosResponse
            {
                AcompananteID = Horarios.AcompananteID,
                Lunes = Convert.ToString(Horarios.Lunes, 2).PadLeft(3, '0'),
                Martes = Convert.ToString(Horarios.Martes, 2).PadLeft(3, '0'),
                Miercoles = Convert.ToString(Horarios.Miercoles, 2).PadLeft(3, '0'),
                Jueves = Convert.ToString(Horarios.Jueves, 2).PadLeft(3, '0'),
                Viernes = Convert.ToString(Horarios.Viernes, 2).PadLeft(3, '0'),
                Sabado = Convert.ToString(Horarios.Sabado, 2).PadLeft(3, '0'),
                Domingo = Convert.ToString(Horarios.Domingo, 2).PadLeft(3, '0'),
            };
        }
    }
}
