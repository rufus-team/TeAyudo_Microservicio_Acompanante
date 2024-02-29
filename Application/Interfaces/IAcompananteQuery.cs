﻿using Application.Model.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAcompananteQuery
    {
        Task<List<Acompanante>> GetAllAcompanante();
        Task<Acompanante?> GetAcompananteByUsuarioID(int UsuarioID);
        Task<Acompanante?> GetAcompananteByID(int AcompananteID);
    }
}
