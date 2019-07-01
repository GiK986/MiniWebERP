namespace MiniWebERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MiniWebERP.Data.Common.Models;

    public class Employee : BaseDeletableModel<string>
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(40)]
        public string LastName { get; set; }

        public string JobTitleId { get; set; }

        public string ManagerID { get; set; }

        public Employee Manager { get; set; }

        public JobTitle JobTitle { get; set; }

        public ICollection<Employee> Subordinates { get; set; }
    }
}
