namespace MiniWebERP.Services.Data.Employees
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MiniWebERP.Services.Data.Models.Employees;

    public interface IEmployeesService
    {
        Task<ICollection<EmployeeServiceModel>> GetAllEmployees();

        Task CreateEmployee(EmployeeInputServiceModel employeeInputServiceModel);

        Task<IEnumerable<EmpoyeeSelectListItem>> GetManagersSelectList();
    }
}
