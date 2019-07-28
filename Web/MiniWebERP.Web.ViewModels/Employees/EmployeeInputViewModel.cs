namespace MiniWebERP.Web.ViewModels.Employees
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class EmployeeInputViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitleId { get; set; }

        public IEnumerable<SelectListItem> JobTitles { get; set; }

        public string ManagerId { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; }

        public bool IsActiveApplicationUser { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
