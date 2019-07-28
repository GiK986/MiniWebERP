namespace MiniWebERP.Services.Data.Models.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class EmployeeServiceModel : IMapFrom<Employee>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitleName { get; set; }

        public string ManagerFullName { get; set; }

        public string AplicationUserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Employee, EmployeeServiceModel>()
                .ForMember(
                    m => m.JobTitleName,
                    opt => opt.MapFrom(x => x.JobTitle.Name))
                .ForMember(
                    m => m.ManagerFullName,
                    opt => opt.MapFrom(x => x.Manager.FirstName + " " + x.Manager.LastName))
               .ForMember(
                    m => m.AplicationUserName,
                    opt => opt.MapFrom(x => x.ApplicationUser.UserName));
        }
    }
}
