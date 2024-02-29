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


        public async Task<Acompanante?> GetAcompananteByID(int AcompananteID)
        {
            Acompanante? Acompanante = await AcompananteContext.Acompanante.FindAsync(AcompananteID);
            return Acompanante; 
        }


        public async Task<Acompanante?> GetAcompananteByUsuarioID(int UsuarioID)
        {
            Acompanante? Acompanante = await AcompananteContext.Acompanante.FirstOrDefaultAsync(s => s.UsuarioID == UsuarioID);
            return Acompanante;
        }
    }
}
