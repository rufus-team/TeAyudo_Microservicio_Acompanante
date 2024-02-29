using Application.Interfaces.Querys;
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
    public class TagQuery : ITagQuery
    {
        private readonly AcompananteContext AcompananteContext;

        public TagQuery(AcompananteContext AcompananteContext)
        {
            this.AcompananteContext = AcompananteContext;
        }

        public async Task<List<Tag>> GetAllTag() 
        {
            List<Tag> ListTags = await AcompananteContext.Tag.ToListAsync();
            return ListTags;
        }
    }
}
