using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class HorariosCommand : IHorariosCommand
    {
        private readonly AcompananteContext AcompananteContext;

        public HorariosCommand(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }

        public async Task<Horarios> CreateHorarios(Horarios Horarios)
        {
            await AcompananteContext.AddAsync(Horarios);
            await AcompananteContext.SaveChangesAsync();
            return Horarios;
        }
    }
}
