using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ApiServer.Core;
using ApiServer.Core.Models;
using ApiServer.Core.Services;

namespace ApiServer.Services
{
    public class ProblemService : IProblemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProblemService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Problem> CreateProblem(Problem newProblem)
        {
            
            Problem problem = await _unitOfWork.ProblemRepository.GetByIdAsync(newProblem.Id);
            if (problem != null)
            {
                throw new RestException(HttpStatusCode.BadRequest, $"Problem with id {newProblem.Id} already exists.");
            }
            
            await _unitOfWork.ProblemRepository.AddAsync(newProblem);
            await _unitOfWork.CommitAsync();
            return newProblem;
        }

        public async Task<Problem> DeleteProblemById(int id)
        {
            Problem problem = await _unitOfWork.ProblemRepository.GetByIdAsync(id);
            if (problem == null)
            {
                throw new RestException(HttpStatusCode.NotFound, $"Problem with id {id} not found");
            }
            _unitOfWork.ProblemRepository.Remove(problem);
            await _unitOfWork.CommitAsync();
            return problem;
        }

        public async Task<IEnumerable<Problem>> GetAllProblems()
        {
            return await _unitOfWork.ProblemRepository.GetAllAsync();
        }

        public async Task<Problem> GetProblemById(int id)
        {
            var problem = await _unitOfWork.ProblemRepository.GetByIdAsync(id);
            if (problem == null)
            {
                throw new RestException(HttpStatusCode.NotFound, $"Problem with id {id} not found");
            }
            return problem;
        }

        public async Task<Problem> UpdateProblem(int problemId, Problem updatedProblem)  
        // 很特殊，和Java Spring JPA 不同：Spring中Create和update是用同一个Repository方法，通过看primary key是否相同区分； EntityFramework中Create用的是Repository的Add方法，update是内部操作
        {
            Problem problemToBeUpdated = await _unitOfWork.ProblemRepository.GetByIdAsync(problemId);
            if (problemToBeUpdated == null)
            {
                throw new RestException(HttpStatusCode.NotFound, $"Problem with id {problemId} not found");
            }
            problemToBeUpdated.Name = updatedProblem.Name;
            problemToBeUpdated.Description = updatedProblem.Description;
            problemToBeUpdated.Difficulty = updatedProblem.Difficulty;
            await _unitOfWork.CommitAsync();
            return updatedProblem;
        }
    }
}