﻿using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class AcompananteCommand : IAcompananteCommand
    {
        private readonly AcompananteContext AcompananteContext;

        public AcompananteCommand(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }

        public async Task<Acompanante> CreatedAcompanante(Acompanante Acompanante)
        {
            await AcompananteContext.AddAsync(Acompanante);
            await AcompananteContext.SaveChangesAsync();
            return Acompanante;
        }
    }
}
