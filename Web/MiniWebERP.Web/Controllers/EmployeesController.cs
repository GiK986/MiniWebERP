namespace MiniWebERP.Web.Controllers
{
    using System;
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
        private readonly ApplicationDbContext _context;

        public EmployeesController(
            IEmployeesService employeesService,
            ApplicationDbContext context)
        {
            this.employeesService = employeesService;
            _context = context;
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
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.JobTitle)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            var model = new EmployeeInputViewModel
            {
                JobTitles = new SelectList(_context.JobTitles, "Id", "Name"),
                Managers = new SelectList(await this.employeesService.GetManagersSelectList(), "Value", "Text"),
            };

            return this.View(model);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeInputViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                _context.Add(input);
                await _context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            input.JobTitles = new SelectList(_context.JobTitles, "Id", "Name", input.JobTitleId);
            input.Managers = new SelectList(await this.employeesService.GetManagersSelectList(), "Value", "Text", input.ManagerId);
            return this.View(input);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["AplicationUserId"] = new SelectList(_context.Users, "Id", "Id", employee.AplicationUserId);
            ViewData["JobTitleId"] = new SelectList(_context.JobTitles, "Id", "Name", employee.JobTitleId);
            ViewData["ManagerID"] = new SelectList(_context.Employees, "Id", "Id", employee.ManagerID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,JobTitleId,ManagerID,AplicationUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AplicationUserId"] = new SelectList(_context.Users, "Id", "Id", employee.AplicationUserId);
            ViewData["JobTitleId"] = new SelectList(_context.JobTitles, "Id", "Name", employee.JobTitleId);
            ViewData["ManagerID"] = new SelectList(_context.Employees, "Id", "Id", employee.ManagerID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.JobTitle)
                .Include(e => e.Manager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
