namespace MiniWebERP.Services.Data.Models.Customers
{
    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class CustomerDetailsServiceModel : IMapFrom<Customer>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string EIK { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string DeliveryCity { get; set; }

        public string DeliveryAddressLine1 { get; set; }

        public string DeliveryAddressLine2 { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactPersonFirstName { get; set; }

        public string ContactPersonLastName { get; set; }

        public string ContactPersonPreferredName { get; set; }

        public string ContactPersonPhoneNumber { get; set; }

        public string ContactPersonEmailAddress { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerDetailsServiceModel>()
                .ForMember(
                    m => m.ContactPersonFirstName,
                    opt => opt.MapFrom(x => x.ContactPerson.FirstName))
                .ForMember(
                    m => m.ContactPersonLastName,
                    opt => opt.MapFrom(x => x.ContactPerson.LastName))
                .ForMember(
                    m => m.ContactPersonPreferredName,
                    opt => opt.MapFrom(x => x.ContactPerson.PreferredName))
                .ForMember(
                    m => m.ContactPersonPhoneNumber,
                    opt => opt.MapFrom(x => x.ContactPerson.PhoneNumber))
                .ForMember(
                    m => m.ContactPersonEmailAddress,
                    opt => opt.MapFrom(x => x.ContactPerson.EmailAddress));
        }
    }
}
