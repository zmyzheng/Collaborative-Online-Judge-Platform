using ApiServer.Core.Models;
using ApiServer.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Data
{
    public class ApiServerDbContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }
        // Note that if you do not plan to manage or fetch data individually from a table, you do not necessarily need to add a DbSet for it, Entity Framework will create that table as long as the model has any relation with the other models.

        public ApiServerDbContext(DbContextOptions<ApiServerDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProblemConfiguration());
        }
    }
}