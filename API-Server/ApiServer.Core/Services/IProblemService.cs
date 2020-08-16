using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer.Core.Models;

namespace ApiServer.Core.Services
{
    public interface IProblemService
    {
        Task<IEnumerable<Problem>> GetAllProblems();
        Task<Problem> GetProblemById(int id);
        Task<Problem> CreateProblem(Problem newProblem);
        Task<Problem> UpdateProblem(int problemId, Problem updatedProblem);
        Task<Problem> DeleteProblemById(int id);
    }
}