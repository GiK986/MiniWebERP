namespace MiniWebERP.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MiniWebERP.Data;
    using MiniWebERP.Data.Models;
    using MiniWebERP.Services.Data.Employees;
    using MiniWebERP.Services.Mapping;
    using MiniWebERP.Web.ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeesService;
        private readonly ApplicationDbContext context;

        public EmployeesController(
            IEmployeesService employeesService,
            ApplicationDbContext context)
        {
            this.employeesService = employeesService;
            this.context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var emp = await this.employeesService.GetAllEmployees();
            var model = emp.MapTo<IEnumerable<EmployeeViewModel>>();
            return this.View(model);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.JobTitle)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var model = new EmployeeInputViewModel
            {
                JobTitles = new SelectList(this.context.JobTitles, "Id", "Name"),
                Managers = new SelectList(await this.employeesService.GetManagersSelectList(), "Value", "Text"),
            };

            return this.View(model);
        }

        // POST: Employees/Create
        // To protect from overPosting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeInputViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(input);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            input.JobTitles = new SelectList(this.context.JobTitles, "Id", "Name", input.JobTitleId);
            input.Managers = new SelectList(await this.employeesService.GetManagersSelectList(), "Value", "Text", input.ManagerId);
            return this.View(input);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees.FindAsync(id);
            if (employee == null)
            {
                return this.NotFound();
            }

            this.ViewData["ApplicationUserId"] = new SelectList(this.context.Users, "Id", "Id", employee.ApplicationUserId);
            this.ViewData["JobTitleId"] = new SelectList(this.context.JobTitles, "Id", "Name", employee.JobTitleId);
            this.ViewData["ManagerID"] = new SelectList(this.context.Employees, "Id", "Id", employee.ManagerID);

            return this.View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overPosting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,JobTitleId,ManagerID,ApplicationUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Employee employee)
        {
            if (id != employee.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.context.Update(employee);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.EmployeeExists(employee.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["ApplicationUserId"] = new SelectList(this.context.Users, "Id", "Id", employee.ApplicationUserId);
            this.ViewData["JobTitleId"] = new SelectList(this.context.JobTitles, "Id", "Name", employee.JobTitleId);
            this.ViewData["ManagerID"] = new SelectList(this.context.Employees, "Id", "Id", employee.ManagerID);
            return this.View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.JobTitle)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await this.context.Employees.FindAsync(id);
            this.context.Employees.Remove(employee);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool EmployeeExists(string id)
        {
            return this.context.Employees.Any(e => e.Id == id);
        }
    }
}
