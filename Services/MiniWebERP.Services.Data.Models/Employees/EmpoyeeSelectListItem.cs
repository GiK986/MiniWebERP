namespace MiniWebERP.Services.Data.Models.Employees
{
    using AutoMapper;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Mapping;

    public class EmpoyeeSelectListItem : IMapFrom<Employee>, IHaveCustomMappings
    {
        public string Text { get; set; }

        public string Value { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Employee, EmpoyeeSelectListItem>()
                .ForMember(
                    m => m.Text,
                    opt => opt.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(
                    m => m.Value,
                    opt => opt.MapFrom(x => x.Id));
        }
    }
}
