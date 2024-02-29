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
    public class AcompananteService : IAcompananteService
    {
        private readonly IAcompananteCommand AcompananteCommand;
        private readonly IAcompananteQuery AcompananteQuery;

        public AcompananteService(IAcompananteCommand AcompananteCommand, IAcompananteQuery AcompananteQuery) 
        {
            this.AcompananteCommand = AcompananteCommand;
            this.AcompananteQuery = AcompananteQuery;
        }

        public async Task<List<AcompananteResponse>> GetAllAcompanante()
        {
            List<Acompanante> Lista = await AcompananteQuery.GetAllAcompanante();
            AcompananteMapper Mapper = new AcompananteMapper();
            List<AcompananteResponse> ListaResponse = Mapper.ListaAcompananteToListaResponse(Lista);
            return ListaResponse;
        }


        public async Task<AcompananteResponse?> GetAcompananteByUsuarioId(int UsuarioId)
        {
            Acompanante? Acompanante = await AcompananteQuery.GetAcompananteByUsuarioID(UsuarioId);
            if (Acompanante == null)
            {
                return null;
            }
            AcompananteMapper Mapper = new AcompananteMapper();
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            return AcompananteResponse;
        }

        
        
        
        
        public async Task<AcompananteResponse?> GetAcompananteById(int AcompananteId)
        {
            Acompanante? Acompanante = await AcompananteQuery.GetAcompananteByID(AcompananteId);
            if (Acompanante == null) 
            {  
                return null; 
            }
            AcompananteMapper Mapper = new AcompananteMapper();
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            return AcompananteResponse;
        }

        public async Task<AcompananteResponse> CreateAcompanante(int UsuarioId)
        {
            AcompananteMapper Mapper = new AcompananteMapper();
            Acompanante Acompanante = new Acompanante() 
            { 
                UsuarioID = UsuarioId 
            };
            Acompanante = await AcompananteCommand.CreatedAcompanante(Acompanante);
            AcompananteResponse AcompananteResponse = Mapper.AcompananteToResponse(Acompanante);
            return AcompananteResponse;
        }
    
    
    
    }
}
