using Application.Interfaces.Commands;
using Application.Interfaces.Querys;
using Application.Interfaces.Service;
using Application.Mappers;
using Application.Model.DTOs;
using Application.Model.Responses;
using Domain.Entities;
using System.Data;

namespace Application.Services
{
    public class AcompananteService : IAcompananteService
    {
        private readonly IAcompananteCommand AcompananteCommand;
        private readonly IAcompananteQuery AcompananteQuery;
        private readonly ITagQuery TagQuery;
        private readonly IUsuarioQuery UsuarioQuery;

        public AcompananteService(IAcompananteCommand AcompananteCommand, IAcompananteQuery AcompananteQuery, ITagQuery TagQuery, IUsuarioQuery UsuarioQuery)
        {
            this.AcompananteCommand = AcompananteCommand;
            this.AcompananteQuery = AcompananteQuery;
            this.TagQuery = TagQuery;
            this.UsuarioQuery = UsuarioQuery;
        }


        public async Task<List<AcompananteResponse>> GetAllAcompanante()
        {
            List<Acompanante> Lista = await AcompananteQuery.GetAllAcompanante();
            AcompananteMapper Mapper = new AcompananteMapper();
            List<AcompananteResponse> ListaResponse = Mapper.ListaAcompananteToListaResponse(Lista);
            List<AcompananteResponse> ListUserComplete = new List<AcompananteResponse>();
            DatosUsuarioMapper datosUsuarioMapper = new DatosUsuarioMapper();
            if (ListaResponse.Count > 0)
            {
                foreach (var AT in ListaResponse)
                {
                    UsuarioResponse? DatosAT = await UsuarioQuery.GetDateAt(AT.UsuarioID);
                    ListUserComplete.Add(datosUsuarioMapper.SetDatosAt(DatosAT, AT));
                }
            }
            return ListUserComplete;
        }


        public async Task<AcompananteResponse?> GetAcompananteByUsuarioID(int UsuarioID)
        {
            Acompanante? Acompanante = await AcompananteQuery.GetAcompananteByUsuarioID(UsuarioID);
            if (Acompanante == null)
            {
                return null;
            }
            AcompananteMapper Mapper = new AcompananteMapper();
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            UsuarioResponse? DatosAT = await UsuarioQuery.GetDateAt(UsuarioID);
            DatosUsuarioMapper datosUsuarioMapper = new DatosUsuarioMapper();
            AcompananteResponse = datosUsuarioMapper.SetDatosAt(DatosAT,AcompananteResponse);
            return AcompananteResponse;
        }


        public async Task<AcompananteResponse?> GetAcompananteByID(int AcompananteID)
        {
            Acompanante? Acompanante = await AcompananteQuery.GetAcompananteByID(AcompananteID);
            if (Acompanante == null)
            {
                return null;
            }
            AcompananteMapper Mapper = new AcompananteMapper();
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            UsuarioResponse? DatosAT = await UsuarioQuery.GetDateAt(AcompananteResponse.UsuarioID);
            DatosUsuarioMapper datosUsuarioMapper = new DatosUsuarioMapper();
            AcompananteResponse = datosUsuarioMapper.SetDatosAt(DatosAT, AcompananteResponse);
            return AcompananteResponse;
        }


        public async Task<List<TagResponse>> GetTagByAcompananteID(int AcompananteID)
        {
            TagMapper Mapper = new TagMapper();
            Acompanante? Acompanante = await AcompananteQuery.GetAcompananteByID(AcompananteID);
            if (Acompanante == null)
            {
                throw new Exception("No existe el acompañante buscado");
            }
            List<TagResponse> ListTagResponse = Mapper.ListTagToListResponse(Acompanante.Tags);
            return ListTagResponse;
        }



        public async Task<AcompananteResponse> CreateAcompanante(AcompananteDTO AcompananteDTO)
        {
            AcompananteMapper Mapper = new AcompananteMapper();
            Acompanante Acompanante = Mapper.DtoToAcompanante(AcompananteDTO);
            Acompanante = await AcompananteCommand.CreatedAcompanante(Acompanante);
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            UsuarioResponse? DatosAT = await UsuarioQuery.GetDateAt(AcompananteDTO.UsuarioID);
            DatosUsuarioMapper datosUsuarioMapper = new DatosUsuarioMapper();
            AcompananteResponse = datosUsuarioMapper.SetDatosAt(DatosAT, AcompananteResponse);
            return AcompananteResponse;
        }


        public async Task<List<TagResponse>> AddCaracteristicas(int AcompananteID, List<TagDTO> ListTagDTO)
        {
            Tag? Tag;
            List<Tag> ListaTag = new List<Tag>();
            foreach (TagDTO TagDTO in ListTagDTO)
            {
                Tag = await TagQuery.GetTagById(TagDTO.TagID);
                if (Tag != null)
                {
                    ListaTag.Add(Tag);
                }
            }
            ListaTag = await AcompananteCommand.AddCarectiscas(AcompananteID, ListaTag);
            TagMapper Mapper = new TagMapper();
            List<TagResponse> ListTagResponse = Mapper.ListTagToListResponse(ListaTag);
            return ListTagResponse;
        }



    }
}
