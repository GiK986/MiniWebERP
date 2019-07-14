namespace MiniWebERP.Web.ViewModels.Customers
{
    using System.ComponentModel.DataAnnotations;

    using MiniWebERP.Services.Data.Models.Customers;
    using MiniWebERP.Services.Mapping;

    public class CustomerDetailsViewModel : IMapFrom<CustomerDetailsServiceModel>
    {
        public string Id { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string EIK { get; set; }

        public string City { get; set; }

        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Delivery City")]
        public string DeliveryCity { get; set; }

        [Display(Name = "Delivery Address Line 1")]
        public string DeliveryAddressLine1 { get; set; }

        [Display(Name = "Delivery Address Line 2")]
        public string DeliveryAddressLine2 { get; set; }

        [Display(Name = "Company Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string ContactPersonFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string ContactPersonLastName { get; set; }

        [Display(Name = "Preferred Name")]
        public string ContactPersonPreferredName { get; set; }

        [Display(Name = "Phone Number")]
        public string ContactPersonPhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        public string ContactPersonEmailAddress { get; set; }
    }
}
