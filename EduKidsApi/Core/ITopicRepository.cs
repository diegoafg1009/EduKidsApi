using EduKidsApi.Dtos;
using EduKidsApi.Models;

namespace EduKidsApi.Core
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        Task<IEnumerable<TopicDto>> GetByMatterIdAsync(Guid matterId);
    }
}
