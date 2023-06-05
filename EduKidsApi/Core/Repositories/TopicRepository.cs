using EduKidsApi.Data;
using EduKidsApi.Dtos;
using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduKidsApi.Core.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TopicDto>> GetByMatterIdAsync(Guid matterId)
        {
            return await _context.Topics
                .Where(t => t.MatterId == matterId)
                .Select(x => new TopicDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Difficult = x.Difficult!.Name,
                    Matter = x.Matter!.Name
                })
                .ToListAsync();
        }
    }
}
