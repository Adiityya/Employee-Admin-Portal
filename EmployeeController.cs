using System;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ApplicationDbContext _Db;

        public EmployeeController(ApplicationDbContext context)
		{
            this._Db = context;
		}
        public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
        {
            var totalEmployees = await _Db.Employees.CountAsync();

            var employees = await _Db.Employees
                .OrderBy(e => e.Emp_Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalEmployees / pageSize);

            return View(employees);
        }

        public IActionResult  Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(Employee Obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Add(Obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }

            return View(Obj);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var employees = await _Db.Employees.FindAsync(id);
            if(employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee Obj)
        {
            if(id != Obj.Emp_Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _Db.Update(Obj);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(Obj);
        }
        public async Task<IActionResult> Details(int id)
        {
            var employees = await _Db.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _Db.Employees.FindAsync(id);
            if(employee != null)
            {
                _Db.Employees.Remove(employee);
                await _Db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Employee Deleted Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Employee Not Found";
            }
            return RedirectToAction("Index");
        }
    }
}

