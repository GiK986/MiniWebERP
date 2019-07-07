namespace MiniWebERP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class Item : BaseDeletableModel<string>
    {
        [Required]
        public int ItemTypeId { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        public decimal UnitPrice { get; set; }

        public ItemType ItemType { get; set; }
    }
}
