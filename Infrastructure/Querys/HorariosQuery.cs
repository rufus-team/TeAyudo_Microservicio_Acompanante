using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class HorariosQuery : IHorariosQuery
    {
        private readonly AcompananteContext AcompananteContext;

        public HorariosQuery(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }


        public async Task<Horarios?> GetHorariosByAcompananteId(int AcompananteID)
        {
            Horarios? Horarios = await AcompananteContext.Horarios.FindAsync(AcompananteID);
            return Horarios;
        }
    }
}
