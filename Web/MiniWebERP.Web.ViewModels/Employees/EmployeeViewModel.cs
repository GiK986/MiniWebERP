namespace MiniWebERP.Web.ViewModels.Employees
{
    using MiniWebERP.Services.Data.Models.Employees;
    using MiniWebERP.Services.Mapping;

    public class EmployeeViewModel : IMapFrom<EmployeeServiceModel>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitleName { get; set; }

        public string ManagerFullName { get; set; }

        public string AplicationUserName { get; set; }
    }
}
