using ApiServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiServer.Data.Configurations
{
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder
                .HasKey(problem => problem.Id);

            builder
                .Property(problem => problem.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Problems");
        }
    }
}