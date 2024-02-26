using Application.Interfaces;
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
            List<Acompanante> ListaResponse = await AcompananteQuery.GetAllAcompanante();

        }

















        public Task<int> CreateAcompanante(int UsuarioID)
        {
            throw new NotImplementedException();
        }

        public Task<AcompananteResponse?> GetAcompananteByUsuarioId(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
