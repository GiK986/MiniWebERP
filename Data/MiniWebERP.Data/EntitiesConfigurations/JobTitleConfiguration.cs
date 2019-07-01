namespace MiniWebERP.Data.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MiniWebERP.Data.Models;

    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasMany(jobTitle => jobTitle.Employees)
                .WithOne(employee => employee.JobTitle)
                .HasForeignKey(employee => employee.JobTitleId)
                .IsRequired();
        }
    }
}
