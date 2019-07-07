namespace MiniWebERP.Data.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MiniWebERP.Data.Models;

    public class ItemTypeConficuration : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.HasMany(it => it.Items)
                .WithOne(i => i.ItemType)
                .HasForeignKey(i => i.ItemTypeId);
        }
    }
}
