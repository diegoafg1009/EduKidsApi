using EduKidsApi.Data;
using EduKidsApi.Models;

namespace EduKidsApi.Core.Repositories
{
    public class ResponseRepository : GenericRepository<Response>, IResponseRepository
    {
        public ResponseRepository(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}
