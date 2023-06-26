using EduKidsApi.Data;
using EduKidsApi.Dtos;
using EduKidsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EduKidsApi.Core.Repositories
{
    public class ResponseDetailRepository : GenericRepository<ResponseDetail>, IResponseDetailRepository
    {
        public ResponseDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ResponseDetailDto>> GetByResponseId(Guid responseId)
        {
            return await Task.Run(() =>
            {
                return Context.ResponseDetails
                    .Include(x => x.Response)
                    .Include(x => x.Alternative)
                    .Where(x => x.ResponseId == responseId)
                    .Select(x => new ResponseDetailDto
                    {
                        Question = x.Alternative!.Question!.Text,
                        Alternative = x.Alternative.Text,
                        IsCorrect = x.Alternative.IsCorrect
                    });
            });
        }
    }
}
