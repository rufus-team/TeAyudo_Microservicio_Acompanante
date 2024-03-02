using Application.Interfaces.Querys;
using Application.Interfaces.Service;
using Application.Mappers;
using Application.Model.Responses;
using Domain.Entities;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagQuery TagQuery;

        public TagService(ITagQuery TagQuery)
        {
            this.TagQuery = TagQuery;
        }

        public async Task<List<TagResponse>> GetAllTag()
        {
            List<Tag> ListTag = await TagQuery.GetAllTag();
            TagMapper Mapper = new TagMapper();
            List<TagResponse> ListTagResponse = Mapper.ListTagToListResponse(ListTag);
            return ListTagResponse;
        }
    }
}
