using System.Collections.Generic;
using System.Threading.Tasks;
using ApiServer.Api.Resources;
using ApiServer.Core.Models;
using ApiServer.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProblemsController : ControllerBase
    {
        private readonly IProblemService _problemService;
        private readonly IMapper _mapper;

        public ProblemsController(IProblemService problemService, IMapper mapper)
        {
            this._problemService = problemService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProblemResource>>> GetAllProblems()
        {
            var problems = await _problemService.GetAllProblems();
            var problemResources = _mapper.Map<IEnumerable<Problem>, IEnumerable<ProblemResource>>(problems);
            return Ok(problemResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProblemResource>> GetProblemById(int id)
        {
            var problem = await _problemService.GetProblemById(id);
            var problemResource = _mapper.Map<Problem, ProblemResource>(problem);
            return Ok(problemResource);
        }


        [HttpPost("")]
        public async Task<ActionResult<ProblemResource>> CreateProblem([FromBody] ProblemResource newProblem)
        {
            var problemToCreate = _mapper.Map<ProblemResource, Problem>(newProblem);
            var problemCreated = await _problemService.CreateProblem(problemToCreate);
            var problemResource = _mapper.Map<Problem, ProblemResource>(problemCreated);
            return Ok(problemResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProblemResource>> UpdateProblem(int id, [FromBody] ProblemResource updatedProblemResource)
        {
            var problem = _mapper.Map<ProblemResource, Problem>(updatedProblemResource);
            var updatedProblem = await _problemService.UpdateProblem(id, problem);
            var problemResource = _mapper.Map<Problem, ProblemResource>(updatedProblem);
            return Ok(problemResource);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProblemResource>> DeleteProblem(int id)
        {
            var problemDeleted = await _problemService.DeleteProblemById(id);
            var problemResource = _mapper.Map<Problem, ProblemResource>(problemDeleted);
            return Ok(problemResource);
        }
    }
}