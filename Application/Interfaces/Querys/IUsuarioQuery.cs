using Application.Model.Responses;

namespace Application.Interfaces.Querys
{
    public interface IUsuarioQuery
    {
        public Task<UsuarioResponse?> GetDateAt(int Id);
    }
}
