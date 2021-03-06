﻿namespace MiniWebERP.Services.Data.Customers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MiniWebERP.Data.Common.Repositories;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Data.Models.Customers;
    using MiniWebERP.Services.Mapping;
    using MiniWebERP.Web.ViewModels.Customers;

    public class CustomersService : ICustomersService
    {
        private readonly IDeletableEntityRepository<Customer> customerRepository;

        public CustomersService(IDeletableEntityRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task CreateCustomer(CustomerInputModel input)
        {
            var contactPerson = new ContactPerson
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                PreferredName = input.PreferredName,
                PhoneNumber = input.PhoneNumber,
                EmailAddress = input.EmailAddress,
            };

            var customer = new Customer
            {
                CompanyName = input.CompanyName,
                EIK = input.EIK,
                City = input.City,
                AddressLine1 = input.AddressLine1,
                AddressLine2 = input.AddressLine2,
                PhoneNumber = input.CompanyPhoneNumber,
                ContactPerson = contactPerson,
            };

            if (input.IsTheSameDeliveryAddress)
            {
                customer.DeliveryCity = customer.City;
                customer.DeliveryAddressLine1 = customer.AddressLine1;
                customer.DeliveryAddressLine2 = customer.AddressLine2;
            }
            else
            {
                customer.DeliveryCity = input.City;
                customer.DeliveryAddressLine1 = input.AddressLine1;
                customer.DeliveryAddressLine2 = input.AddressLine2;
            }

            await this.customerRepository.AddAsync(customer);
            await this.customerRepository.SaveChangesAsync();
        }

        public async Task DeleteCustomer(string id)
        {
            var entity = this.customerRepository.Find(id);
            this.customerRepository.Delete(entity);
            await this.customerRepository.SaveChangesAsync();
        }

        public IQueryable<Customer> GetAll()
        {
            var result = this.customerRepository.All();
            return result;
        }

        public async Task<ICollection<CustomerListServiceModel>> GetAllCustomersOrderByCompaniName()
        {
            var result = await this.customerRepository.All()
                .To<CustomerListServiceModel>()
                .OrderBy(c => c.CompanyName)
                .ToListAsync();

            return result;
        }

        public IQueryable<Customer> GetCustomerById(string id)
        {
            var result = this.customerRepository.All().Include(c => c.ContactPerson).Where(c => c.Id == id);
            return result;
        }

        public async Task<CustomerDetailsServiceModel> GetCustomerDetails(string id)
        {
            var customer = await this.customerRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id).To<CustomerDetailsServiceModel>()
                .FirstOrDefaultAsync();

            return customer;
        }
    }
}
