namespace MiniWebERP.Data.Models
{
    using System.Collections.Generic;

    using MiniWebERP.Data.Common.Models;

    public class ItemType : BaseCatalogModel<int>
    {
        public ItemType()
        {
            this.Items = new HashSet<Item>();
        }

        public virtual ICollection<Item> Items { get; set; }
    }
}
