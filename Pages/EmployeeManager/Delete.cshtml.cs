using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Razor.Pages.EmployeeManager
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext db = null;

        // BindProperty attribute indicates that the property will get 
        // its value from the model binding, at post
        [BindProperty]
        public Employee Employee { get; set; }
        public string Message { get; set; }
        public bool DataFound { get; set; }

        public DeleteModel(AppDbContext db)
        {
            this.db = db;
        }
        public void OnGet(int id)
        {
            Employee = db.Employees.Find(id);

            if (Employee == null)
            {
                DataFound = false;
                Message = "Employee ID not found.";
            }
            else
            {
                DataFound = true;
                Message = "";
            }
        }
        public IActionResult OnPost()
        {
            Employee emp = db.Employees.Find(Employee.EmployeeID);
            try
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                TempData["Message"] = "Employee was deleted.";
                return RedirectToPage("/EmployeeManager/List");
            }
            catch (DbUpdateException ex1)
            {
                Message = ex1.Message;
                if (ex1.InnerException != null)
                {
                    Message += ": " + ex1.InnerException.Message;
                }
            }
            catch (Exception ex2)
            {
                Message = ex2.Message;
            }

            return Page();
        }
    }
}
