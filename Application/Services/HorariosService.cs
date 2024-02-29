using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Service;
using Application.Mappers;
using Application.Model.DTOs;
using Application.Model.Responses;
using Domain.Entities;

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


        public async Task<HorariosResponse?> GetHorariosByAcompananteID(int AcompananteID)
        {
            Horarios? Horarios = await HorariosQuery.GetHorariosByAcompananteID(AcompananteID);
            if (Horarios == null)
            {
                return null;
            }
            HorariosMapper Mapper = new HorariosMapper();
            HorariosResponse HorariosResponse = Mapper.HorariosToResponse(Horarios);
            return HorariosResponse;
        }



        public async Task<List<HorariosIdResponse>> GetHorariosIdByFiltro(HorariosDtoFiltro HorariosDtoFiltro)
        {
            HorariosMapper Mapper = new HorariosMapper();
            Horarios Horarios = Mapper.DtoFiltroToHorarios(HorariosDtoFiltro);
            List<Horarios> ListaHorarios = await HorariosQuery.GetHorariosByFiltro(Horarios);
            List<HorariosIdResponse> ListaHorariosIdResponse = Mapper.ListaHorariosToHorariosId(ListaHorarios);
            return ListaHorariosIdResponse;

        }





        public async Task<HorariosResponse> AddHorarios(HorariosDTO HorariosDTO)
        {
            HorariosMapper Mapper = new HorariosMapper();
            Horarios Horarios = Mapper.DtoToHorarios(HorariosDTO);
            Horarios = await HorariosCommand.AddHorarios(Horarios);
            HorariosResponse HorariosResponse = Mapper.HorariosToResponse(Horarios);
            return HorariosResponse;
        }


    }
}
