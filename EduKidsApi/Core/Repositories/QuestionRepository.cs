using EduKidsApi.Data;
using EduKidsApi.Dtos;
using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduKidsApi.Core.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<QuestionDto>> GetWithAlternatives()
        {
            var questions = await Context.Questions
                .Select(x => new QuestionDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    Alternatives = x.Alternatives
                })
                .ToListAsync();
            return questions;
        }
        
        public async Task<IEnumerable<Question>> GetQuestionsPerTopic()
        {
            throw new NotImplementedException();
            //var random = new Random();
            //var randomItem = await Context.Topics
            //    .Include(x => x.Questions)
            //    .AsEnumerable()
            //    .Select(x => new Question
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        Difficult = x.Difficult!.Name,
            //        Matter = x.Matter!.Name
            //    });

        }
    }
}
