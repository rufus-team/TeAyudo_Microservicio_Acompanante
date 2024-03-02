using Application.Model.Responses;

namespace Application.Interfaces.Service
{
    public interface ITagService
    {
        Task<List<TagResponse>> GetAllTag();
    }
}
