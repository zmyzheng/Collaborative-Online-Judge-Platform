using System.Threading.Tasks;
using ApiServer.Core;
using ApiServer.Core.Repositories;
using ApiServer.Data.Repositories;

namespace ApiServer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiServerDbContext _context;
        private ProblemRepository _problemRepository;

        public UnitOfWork(ApiServerDbContext context)
        {
            this._context = context;
        }
 
        public IProblemRepository ProblemRepository => _problemRepository = _problemRepository ?? new ProblemRepository(_context);


        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}