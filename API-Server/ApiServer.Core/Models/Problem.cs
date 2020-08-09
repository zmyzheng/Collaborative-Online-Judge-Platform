namespace ApiServer.Core.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EDifficulty Difficulty { get; set; }
    }
}