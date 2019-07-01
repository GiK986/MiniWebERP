namespace MiniWebERP.Data.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseCatalogModel<TKey> : ICatalogEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [StringLength(60)]
        [Required]
        public string Name { get; set; }
    }
}
