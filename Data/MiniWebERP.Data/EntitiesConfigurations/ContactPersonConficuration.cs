namespace MiniWebERP.Data.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MiniWebERP.Data.Models;

    public class ContactPersonConficuration : IEntityTypeConfiguration<ContactPerson>
    {
        public void Configure(EntityTypeBuilder<ContactPerson> builder)
        {
            builder.HasOne(cp => cp.Customer)
                .WithOne(c => c.ContactPerson)
                .HasForeignKey<Customer>(c => c.ContactPersonID);
        }
    }
}
