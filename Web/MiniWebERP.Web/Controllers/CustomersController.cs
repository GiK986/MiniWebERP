namespace MiniWebERP.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MiniWebERP.Services.Data.Customers;
    using MiniWebERP.Services.Mapping;
    using MiniWebERP.Web.ViewModels.Customers;

    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        public async Task<IActionResult> Index()
        {
            var customersServiceModel = await this.customersService.GetAllCustomersOrderByCompaniName();

            var customersViewModel = customersServiceModel.MapTo<ICollection<CustomerViewModel>>();

            var model = new CustomersListViewModel
            {
                Customers = customersViewModel,
            };
            return this.View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var customer = await this.customersService.GetCustomerDetails(id);

            var model = customer.MapTo<CustomerDetailsViewModel>();
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CustomerInputModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.customersService.CreateCustomer(input);

            return this.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = this.customersService.GetCustomerById(id).To<CustomerInputModel>().FirstOrDefault();
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.customersService.DeleteCustomer(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
