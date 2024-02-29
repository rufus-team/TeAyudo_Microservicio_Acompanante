using Application.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Service
{
    public interface ITagService
    {
        Task<List<TagResponse>> GetAllTag();
    }
}
