using Application.Interfaces;
using Application.Mappers;
using Application.Model.DTOs;
using Application.Model.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class HorariosService : IHorariosService
    {
        private readonly IHorariosCommand HorariosCommand;
        private readonly IHorariosQuery HorariosQuery;
        public HorariosService(IHorariosCommand HorariosCommand, IHorariosQuery HorariosQuery) 
        {
            this.HorariosCommand = HorariosCommand;
            this.HorariosQuery = HorariosQuery;
        }

        public async Task<HorariosResponse> CreateHorario(int AcompananteID, HorariosDTO HorariosDTO)
        {
            HorariosMapper Mapper = new HorariosMapper();
            Horarios Horarios = Mapper.DtoToHorarios(HorariosDTO);
            Horarios.AcompananteID = AcompananteID;
            Horarios = await HorariosCommand.CreateHorarios(Horarios);
            HorariosResponse HorariosResponse = Mapper.HorariosToResponse(Horarios);
            return HorariosResponse;
        }

        public async Task<HorariosResponse?> GetHorariosByAcompananteId(int AcompananteID)
        {
            Horarios? Horarios = await HorariosQuery.GetHorariosByAcompananteId(AcompananteID);
            if (Horarios == null) 
            {
                return null;
            }
            HorariosMapper Mapper = new HorariosMapper();
            HorariosResponse HorariosResponse = Mapper.HorariosToResponse(Horarios);
            return HorariosResponse;
        }
    }
}
