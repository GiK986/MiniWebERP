namespace MiniWebERP.Services.Data.Models.Customers
{
    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class CustomerListServiceModel : IMapFrom<Customer>, IHaveCustomMappings
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
            configuration.CreateMap<Customer, CustomerListServiceModel>()
                .ForMember(
                    m => m.ContactPerson,
                    opt => opt.MapFrom(x => x.ContactPerson.FirstName + " " + x.ContactPerson.LastName))
                .ForMember(
                    m => m.PhoneNumber,
                    opt => opt.MapFrom(x => x.PhoneNumber));
        }
    }
}
