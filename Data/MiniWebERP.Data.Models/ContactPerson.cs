namespace MiniWebERP.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class ContactPerson : BaseDeletableModel<string>
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string PreferredName { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(256)]
        public string EmailAddress { get; set; }

        public Customer Customer { get; set; }
    }
}
