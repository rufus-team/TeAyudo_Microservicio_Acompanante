using Application.Model.DTOs;
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
        Task<AcompananteResponse?> GetAcompananteByUsuarioId(int UsuarioId);
        Task<AcompananteResponse?> GetAcompananteById(int AcompananteId);
        Task<AcompananteResponse> CreateAcompanante(int UsuarioId);
    }
}
