using EduKidsApi.Dtos;
using EduKidsApi.Models;

namespace EduKidsApi.Core
{
    public interface IResponseDetailRepository : IGenericRepository<ResponseDetail>
    {
        Task<IEnumerable<ResponseDetailDto>> GetByResponseId(Guid responseId);
    }
}
