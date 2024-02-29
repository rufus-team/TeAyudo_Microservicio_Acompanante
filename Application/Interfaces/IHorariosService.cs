using Application.Model.DTOs;
using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHorariosService
    {
        Task<HorariosResponse> CreateHorario(int AcompananteID, HorariosDTO HorariosDTO);
        Task<HorariosResponse?> GetHorariosByAcompananteId(int AcompananteID);
    }
}
