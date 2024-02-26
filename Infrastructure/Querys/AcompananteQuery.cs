using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Querys
{
    public class AcompananteQuery : IAcompananteQuery
    {
        private readonly AcompananteContext AcompananteContext;

        public AcompananteQuery (AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }



        public async Task<List<Acompanante>> GetAllAcompanante()
        {
            List<Acompanante> ListaResponse = await AcompananteContext.Acompanante.ToListAsync();
            return ListaResponse;
        }
    }
}
