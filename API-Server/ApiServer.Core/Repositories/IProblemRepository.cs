using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer.Core.Models;

namespace ApiServer.Core.Repositories
{
    public interface IProblemRepository : IRepository<Problem, int>
    {
        Task<Problem> GetProblemByIdAsync(int id);
        Task<IEnumerable<Problem>> GetAllProblemsAsync();
    }
}