namespace MiniWebERP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class OrderLine : BaseDeletableModel<string>
    {
        [Required]
        public string OrderId { get; set; }

        [Required]
        public string ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }
    }
}
