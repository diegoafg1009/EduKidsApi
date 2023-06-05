using EduKidsApi.Core;
using EduKidsApi.Core.Repositories;

namespace EduKidsApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        public IMatterRepository Matters { get; private set; }
        public ITopicRepository Topics { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Matters = new MatterRepository(_context);
            Topics = new TopicRepository(_context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
