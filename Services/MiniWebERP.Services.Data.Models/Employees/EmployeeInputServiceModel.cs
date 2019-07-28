namespace MiniWebERP.Services.Data.Models.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class EmployeeInputServiceModel : IMapTo<Employee>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitleId { get; set; }

        public string ManagerId { get; set; }

        public string AplicationUserId { get; set; }
    }
}
