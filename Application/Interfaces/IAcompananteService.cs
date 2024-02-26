using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAcompananteService
    {
        Task<List<AcompananteResponse>> GetAllAcompanante();
        Task<AcompananteResponse?> GetAcompananteByUsuarioId(int Id);
        Task<int> CreateAcompanante(int UsuarioID);
    }
}
