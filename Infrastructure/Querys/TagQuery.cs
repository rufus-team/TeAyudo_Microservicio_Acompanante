using Application.Interfaces.Querys;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Tag?> GetTagById(int TagID)
        {
            Tag? Tag = await AcompananteContext.Tag.FindAsync(TagID);
            return Tag;
        }
    }
}
