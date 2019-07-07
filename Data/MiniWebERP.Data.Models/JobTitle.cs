namespace MiniWebERP.Data.Models
{
    using System.Collections.Generic;

    using MiniWebERP.Data.Common.Models;

    public class JobTitle : BaseCatalogModel<int>
    {
        public JobTitle()
        {
            this.Employees = new HashSet<Employee>();
        }

        public ICollection<Employee> Employees { get; set; }
    }
}
