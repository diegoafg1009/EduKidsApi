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

        public async Task<IEnumerable<QuestionDto>> GetByTopicIdWithAlternatives(Guid topicId)
        {
            return await Task.Run(() =>
            {
                var random = new Random();
                var questions = Context.Questions
                    .Include(x => x.Alternatives)
                    .Where(x => x.TopicId == topicId)
                    .AsEnumerable()
                .Select(x => new QuestionDto
                {
                    Id = x.Id,
                    Text = x.Text,
                    Alternatives = x.Alternatives
                            .OrderBy(a => random.Next())
                            .Select(a => new AlternativeDto
                            {
                                Id = a.Id,
                                Text = a.Text,
                                IsCorrect = a.IsCorrect
                })
                            .ToList()
                    })
                    .ToList();
            return questions;
            });
        }
        
        public async Task<IEnumerable<QuestionDto>> GetQuestionsPerTopic()
        {
            return await Task.Run(() =>
            {
                var random = new Random();
                var randomQuestions = Context.Topics
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Alternatives)
                    .Where(x => x.Questions.Any())
                    .AsEnumerable()
                    .OrderBy(x => random.Next())
                    .Select(x => x.Questions
                        .MinBy(q => random.Next())
                    );

                return randomQuestions.Select(x => new QuestionDto
                {
                    Id = x!.Id,
                    Text = x.Text,
                    Alternatives = x.Alternatives
                        .OrderBy(a => random.Next())
                        .Select(a => new AlternativeDto
                        {
                            Id = a.Id,
                            Text = a.Text,
                            IsCorrect = a.IsCorrect
                        })
                        .ToList()
                })
                    .ToList();
            });
        }
    }
}
