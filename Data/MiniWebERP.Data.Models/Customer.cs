namespace MiniWebERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class Customer : BaseDeletableModel<string>
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

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

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public virtual ContactPerson ContactPerson { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
