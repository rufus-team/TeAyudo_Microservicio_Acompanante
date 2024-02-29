using Application.Interfaces.Commands;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Commands
{
    public class HorariosCommand : IHorariosCommand
    {
        private readonly AcompananteContext AcompananteContext;

        public HorariosCommand(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }

        public async Task<Horarios> AddHorarios(Horarios Horarios)
        {
            await AcompananteContext.AddAsync(Horarios);
            await AcompananteContext.SaveChangesAsync();
            return Horarios;
        }
    }
}
