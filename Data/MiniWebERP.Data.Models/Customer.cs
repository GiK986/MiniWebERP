namespace MiniWebERP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class Customer : BaseDeletableModel<string>
    {
        [Required]
        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(13)]
        public string EIK { get; set; }

        [StringLength(60)]
        public string City { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(60)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
    }
}
