using EduKidsApi.Data;
using EduKidsApi.Models;

namespace EduKidsApi.Core.Repositories
{
    public class MatterRepository : GenericRepository<Matter>, IMatterRepository
    {
        public MatterRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
