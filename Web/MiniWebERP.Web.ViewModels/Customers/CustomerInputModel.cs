namespace MiniWebERP.Web.ViewModels.Customers
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class CustomerInputModel : IMapFrom<Customer>, IHaveCustomMappings
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [StringLength(13, MinimumLength = 9)]
        public string EIK { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Is The Same Delivery Address")]
        public bool IsTheSameDeliveryAddress { get; set; } = true;

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Delivery City")]
        public string DeliveryCity { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Delivery Address Line 1")]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        [Display(Name = "Delivery Address Line 2")]
        public string DeliveryAddressLine2 { get; set; }

        [StringLength(20)]
        [Display(Name = "Company Phone Number")]
        public string CompanyPhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Preferred Name")]
        public string PreferredName { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(256)]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerInputModel>().ForMember(
                m => m.CompanyPhoneNumber,
                opt => opt.MapFrom(x => x.PhoneNumber)).ForMember(
                m => m.FirstName,
                opt => opt.MapFrom(x => x.ContactPerson.FirstName)).ForMember(
                m => m.LastName,
                opt => opt.MapFrom(x => x.ContactPerson.LastName)).ForMember(
                m => m.PhoneNumber,
                opt => opt.MapFrom(x => x.ContactPerson.PhoneNumber)).ForMember(
                m => m.PreferredName,
                opt => opt.MapFrom(x => x.ContactPerson.PreferredName)).ForMember(
                m => m.EmailAddress,
                opt => opt.MapFrom(x => x.ContactPerson.EmailAddress));
        }
    }
}
