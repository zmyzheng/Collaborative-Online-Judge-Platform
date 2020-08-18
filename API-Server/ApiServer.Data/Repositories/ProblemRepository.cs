using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer.Core.Models;
using ApiServer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Data.Repositories
{
    public class ProblemRepository : Repository<Problem, int>, IProblemRepository
    {
        public ProblemRepository(ApiServerDbContext context) : base(context) {}

        public async Task<IEnumerable<Problem>> GetAllProblemsAsync()
        {
            return await this.GetAllAsync();
        }

        public async Task<Problem> GetProblemByIdAsync(int id)
        {
            // 两种写法都可以
            // return await this.SingleOrDefaultAsync(problem => problem.Id == id);  
            return await ApiServerDbContext.Problems
                .SingleOrDefaultAsync(problem => problem.Id == id);
        }

        private ApiServerDbContext ApiServerDbContext
        {
            get { return Context as ApiServerDbContext; }
        }
    }
}