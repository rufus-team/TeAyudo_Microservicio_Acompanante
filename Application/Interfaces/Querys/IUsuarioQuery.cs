using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Querys
{
    public interface IUsuarioQuery
    {
        public Task<UsuarioResponse?> GetDateAt(int Id);
    }
}
