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
            MapHorariosToHorariosResponse Mapper = new MapHorariosToHorariosResponse();
            HorariosResponse HorariosResponse = Mapper.HorarioToHorariosResponse(Horarios);
            return HorariosResponse;
        }


        public async Task<List<HorariosIdResponse>> GetHorariosIdByFiltro(HorariosDtoFiltro HorariosDtoFiltro)
        {
            MapperHorariosFiltroToHorarios MapperFiltro = new MapperHorariosFiltroToHorarios();
            Horarios Horarios = MapperFiltro.HorariosFiltroToHorarios(HorariosDtoFiltro);
            List<Horarios> ListaHorarios = await HorariosQuery.GetHorariosByFiltro(Horarios);
            HorariosMapper Mapper = new HorariosMapper();
            List<HorariosIdResponse> ListaHorariosIdResponse = Mapper.ListaHorariosToHorariosId(ListaHorarios);
            return ListaHorariosIdResponse;

        }


        public async Task<HorariosResponse> AddHorarios(HorariosDTO HorariosDTO)
        {
            MapperHorariosFiltroToHorarios MapperHorarios = new MapperHorariosFiltroToHorarios();
            Horarios Horarios = MapperHorarios.HorariosDtoToHorarios(HorariosDTO);
            Horarios = await HorariosCommand.AddHorarios(Horarios);
            MapHorariosToHorariosResponse Mapper = new MapHorariosToHorariosResponse();
            HorariosResponse HorariosResponse = Mapper.HorarioToHorariosResponse(Horarios);
            return HorariosResponse;
        }


    }
}
