namespace MiniWebERP.Data.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MiniWebERP.Data.Models;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(manager => manager.Subordinates)
                .WithOne(emp => emp.Manager)
                .HasForeignKey(emp => emp.ManagerID);

            builder.HasMany(emp => emp.Orders)
                .WithOne(o => o.Employee)
                .HasForeignKey(o => o.EmployeeId);
        }
    }
}
