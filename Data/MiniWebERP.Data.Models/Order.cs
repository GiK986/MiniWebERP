﻿namespace MiniWebERP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Data.Common.Models;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }

        [Required]
        public string CustomerID { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        [StringLength(10)]
        public string OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ExpectedImplementationDate { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedWhen { get; set; }

        [StringLength(256)]
        public string Comments { get; set; }

        [StringLength(256)]
        public string InternalComments { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
