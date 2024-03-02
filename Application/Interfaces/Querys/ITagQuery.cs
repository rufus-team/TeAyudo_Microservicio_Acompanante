using Domain.Entities;

namespace Application.Interfaces.Querys
{
    public interface ITagQuery
    {
        Task<List<Tag>> GetAllTag();
        Task<Tag?> GetTagById(int TagID);
    }
}
