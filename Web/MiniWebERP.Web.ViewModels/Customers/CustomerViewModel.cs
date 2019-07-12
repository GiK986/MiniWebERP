namespace MiniWebERP.Web.ViewModels.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class CustomerViewModel : IMapFrom<Customer>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string EIK { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string ContactPerson { get; set; }

        public string PhoneNumber { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerViewModel>().ForMember(
                m => m.ContactPerson,
                opt => opt.MapFrom(x => x.ContactPerson.FirstName + " " + x.ContactPerson.LastName));
        }
    }
}
