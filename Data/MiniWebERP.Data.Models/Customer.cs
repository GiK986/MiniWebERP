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

        [Required]
        [StringLength(60)]
        public string City { get; set; }

        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(60)]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }

        public string ContactPersonID { get; set; }

        // public ContactPerson ContactPerson { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
    }
}
