using Application.Model.DTOs;
using Application.Model.Responses;

namespace Application.Interfaces.Service
{
    public interface IAcompananteService
    {
        Task<List<AcompananteResponse>> GetAllAcompanante();
        Task<AcompananteResponse?> GetAcompananteByUsuarioID(int UsuarioID);
        Task<AcompananteResponse?> GetAcompananteByID(int AcompananteID);
        Task<AcompananteResponse> CreateAcompanante(AcompananteDTO AcompananteDTO);
        Task<List<TagResponse>> AddCaracteristicas (int AcompananteID, List<TagDTO> ListTagDTO);
    }
}
