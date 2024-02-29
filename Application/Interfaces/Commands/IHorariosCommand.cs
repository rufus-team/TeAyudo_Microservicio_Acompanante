using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IHorariosCommand
    {
        Task<Horarios> AddHorarios(Horarios Horarios);
    }
}
