namespace MiniWebERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MiniWebERP.Data.Models;
    using MiniWebERP.Web.ViewModels.Customers;

    public interface ICustomersService
    {
        IQueryable<Customer> GetAll();

        Task CreateCustomer(CustomerInputModel input);

        IQueryable<Customer> GetCustomerById(string id);
    }
}
