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
    }



    [Mapper]

    public partial class HorariosMapper
    {
        public partial Horarios DtoToHorarios(HorariosDTO HorariosDTO);
        public partial HorariosResponse HorariosToResponse (Horarios Horarios);
    }
}
