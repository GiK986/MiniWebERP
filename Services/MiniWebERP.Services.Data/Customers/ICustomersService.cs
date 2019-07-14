namespace MiniWebERP.Services.Data.Customers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Data.Models.Customers;
    using MiniWebERP.Web.ViewModels.Customers;

    public interface ICustomersService
    {
        IQueryable<Customer> GetAll();

        Task<ICollection<CustomerListServiceModel>> GetAllCustomersOrderByCompaniName();

        Task CreateCustomer(CustomerInputModel input);

        IQueryable<Customer> GetCustomerById(string id);

        Task<CustomerDetailsServiceModel> GetCustomerDetails(string id);

        Task DeleteCustomer(string id);
    }
}
