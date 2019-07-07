namespace MiniWebERP.Data.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MiniWebERP.Data.Models;

    public class ItemConficuration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(i => i.UnitPrice)
                 .HasColumnType("decimal(15,2)");
        }
    }

}
