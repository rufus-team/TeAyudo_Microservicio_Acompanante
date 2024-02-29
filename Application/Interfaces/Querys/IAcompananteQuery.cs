using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface IAcompananteQuery
    {
        Task<List<Acompanante>> GetAllAcompanante();
        Task<Acompanante?> GetAcompananteByUsuarioID(int UsuarioID);
        Task<Acompanante?> GetAcompananteByID(int AcompananteID);
    }
}
