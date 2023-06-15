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

        public async Task<IEnumerable<TopicDto>> GetWithFiltersAsync(FilterTopicDto model)
        {
            var topics = await Context.Topics
                .ToListAsync();

            if (model.MatterId != Guid.Empty)
            {
                topics = topics.Where(x => x.MatterId == model.MatterId).ToList();
            }

            if (model.DifficultId != Guid.Empty)
            {
                topics = topics.Where(x => x.DifficultId == model.DifficultId).ToList();
            }

            return topics
                .Select(x => new TopicDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Difficult = x.Difficult!.Name,
                    Matter = x.Matter!.Name
                });
        }
    }
}
