using Application.Model.DTOs;
using Application.Model.Responses;

namespace Application.Interfaces.Service
{
    public interface IHorariosService
    {
        Task<HorariosResponse?> GetHorariosByAcompananteID(int AcompananteID);
        Task<List<HorariosIdResponse>> GetHorariosIdByFiltro(HorariosDtoFiltro HorariosDtoFiltro);
        Task<HorariosResponse> AddHorarios(HorariosDTO HorariosDTO);
    }
}
