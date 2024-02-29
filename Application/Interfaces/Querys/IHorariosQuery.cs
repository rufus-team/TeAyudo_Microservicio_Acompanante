using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IHorariosQuery
    {
        Task<Horarios?> GetHorariosByAcompananteID(int AcompananteID);
        Task<List<Horarios>> GetHorariosByFiltro(Horarios Horarios);
    }
}
