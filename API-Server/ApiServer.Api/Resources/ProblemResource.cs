using ApiServer.Core.Models;

namespace ApiServer.Api.Resources
{
    public class ProblemResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EDifficulty Difficulty { get; set; }
    }
}