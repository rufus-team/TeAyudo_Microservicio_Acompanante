using Application.Interfaces;
using Application.Model.DTOs;
using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HorariosService : IHorariosService
    {
        public Task<string> CreateHorario(int AcompananteID, HorariosDTO HorariosDTO)
        {
            throw new NotImplementedException();
        }

        public Task<HorariosResponse?> GetHorariosByAcompananteId(int AcompananteID)
        {
            throw new NotImplementedException();
        }
    }
}
