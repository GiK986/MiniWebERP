namespace MiniWebERP.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MiniWebERP.Data.Common.Repositories;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Data.Models.Employees;
    using MiniWebERP.Services.Mapping;

    public class EmployeesService : IEmployeesService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepository;

        public EmployeesService(IDeletableEntityRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task CreateEmployee(EmployeeInputServiceModel employeeInputServiceModel)
        {
            var employee = employeeInputServiceModel.MapTo<Employee>();
            await this.employeeRepository.AddAsync(employee);
            await this.employeeRepository.SaveChangesAsync();
        }

        public async Task<ICollection<EmployeeServiceModel>> GetAllEmployees()
        {
            var result = await this.employeeRepository
                .All()
                .To<EmployeeServiceModel>()
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<EmpoyeeSelectListItem>> GetManagersSelectList()
        {
            var result = await this.employeeRepository
                .All()
                .To<EmpoyeeSelectListItem>()
                .ToListAsync();
            return result;
        }
    }
}
