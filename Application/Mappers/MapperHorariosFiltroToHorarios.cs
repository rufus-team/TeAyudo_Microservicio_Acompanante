using Application.Model.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class MapperHorariosFiltroToHorarios
    {
        public Horarios HorariosFiltroToHorarios(HorariosDtoFiltro HorariosDtoFiltro)
        {
            return new Horarios
            {
                Lunes = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Lunes), 2),
                Martes = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Martes), 2),
                Miercoles = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Miercoles), 2),
                Jueves = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Jueves), 2),
                Viernes = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Viernes), 2),
                Sabado = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Sabado), 2),
                Domingo = Convert.ToInt16(("000000000000" + HorariosDtoFiltro.Domingo), 2),
            };
        }

        public Horarios HorariosDtoToHorarios(HorariosDTO HorariosDTO)
        {
            return new Horarios
            {
                AcompananteID = HorariosDTO.AcompananteID,
                Lunes = Convert.ToInt16(("000000000000" + HorariosDTO.Lunes), 2),
                Martes = Convert.ToInt16(("000000000000" + HorariosDTO.Martes), 2),
                Miercoles = Convert.ToInt16(("000000000000" + HorariosDTO.Miercoles), 2),
                Jueves = Convert.ToInt16(("000000000000" + HorariosDTO.Jueves), 2),
                Viernes = Convert.ToInt16(("000000000000" + HorariosDTO.Viernes), 2),
                Sabado = Convert.ToInt16(("000000000000" + HorariosDTO.Sabado), 2),
                Domingo = Convert.ToInt16(("000000000000" + HorariosDTO.Domingo), 2),
            };
        }
















    }
}
