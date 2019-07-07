namespace MiniWebERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class Item : BaseDeletableModel<string>
    {
        public Item()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }

        [Required]
        public int ItemTypeId { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual ItemType ItemType { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
