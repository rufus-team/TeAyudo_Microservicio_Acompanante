using Domain.Entities;

namespace Application.Interfaces.Commands
{
    public interface IAcompananteCommand
    {
        Task<Acompanante> CreatedAcompanante(Acompanante Acompanante);
        Task<List<Tag>> AddCarectiscas(int AcompananteID, List<Tag> ListTag);
    }
}
