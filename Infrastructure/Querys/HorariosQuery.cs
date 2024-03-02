using Application.Interfaces.Querys;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Querys
{
    public class HorariosQuery : IHorariosQuery
    {
        private readonly AcompananteContext AcompananteContext;

        public HorariosQuery(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }


        public async Task<Horarios?> GetHorariosByAcompananteID(int AcompananteID)
        {
            Horarios? Horarios = await AcompananteContext.Horarios.FindAsync(AcompananteID);
            return Horarios;
        }


        public async Task<List<Horarios>> GetHorariosByFiltro(Horarios Horarios)
        {
            List<Horarios> ListaHorarios = await AcompananteContext
                                                    .Horarios
                                                    .Where(s =>
                                                        (s.Lunes & Horarios.Lunes) == Horarios.Lunes &&
                                                        (s.Martes & Horarios.Martes) == Horarios.Martes &&
                                                        (s.Miercoles & Horarios.Miercoles) == Horarios.Miercoles &&
                                                        (s.Jueves & Horarios.Jueves) == Horarios.Jueves &&
                                                        (s.Viernes & Horarios.Viernes) == Horarios.Viernes &&
                                                        (s.Sabado & Horarios.Sabado) == Horarios.Sabado &&
                                                        (s.Domingo & Horarios.Domingo) == Horarios.Domingo
                                                    )
                                                    .ToListAsync();
            return ListaHorarios;
        }
    }
}
