using Application.Model.DTOs;
using Application.Model.Responses;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Mappers
{
    [Mapper]

    public partial class AcompananteMapper
    {
        public partial List<AcompananteResponse> ListaAcompananteToListaResponse(List<Acompanante> ListaAcompanante);
        public partial AcompananteResponse AcompananteToResponse(Acompanante Acompanante);
        public partial Acompanante DtoToAcompanante(AcompananteDTO AcompananteDTO);
    }



    [Mapper]

    public partial class HorariosMapper
    {
        public partial Horarios DtoToHorarios(HorariosDTO HorariosDTO);
        public partial Horarios DtoFiltroToHorarios(HorariosDtoFiltro HorariosDtoFiltro);
        public partial List<HorariosIdResponse> ListaHorariosToHorariosId(List<Horarios> ListaHorarios);
        public partial HorariosResponse HorariosToResponse(Horarios Horarios);
    }


    [Mapper]
    public partial class TagMapper
    {
        public partial List<Tag> ListDtoToList(List<TagDTO> ListaTagDTO);
        public partial List<TagResponse> ListTagToListResponse(List<Tag> Tag);
    }
}
