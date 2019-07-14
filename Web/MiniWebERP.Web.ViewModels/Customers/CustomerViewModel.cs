namespace MiniWebERP.Web.ViewModels.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Data.Models.Customers;
    using MiniWebERP.Services.Mapping;

    public class CustomerViewModel : IMapFrom<CustomerListServiceModel>
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string EIK { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNumber { get; set; }
    }
}
