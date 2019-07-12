namespace MiniWebERP.Web.ViewModels.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomersListViewModel
    {
        public ICollection<CustomerViewModel> Customers { get; set; }
    }
}
