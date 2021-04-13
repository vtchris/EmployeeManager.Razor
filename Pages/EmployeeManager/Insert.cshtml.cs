using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Razor.Pages.EmployeeManager
{
    public class InsertModel : PageModel
    {
        private readonly AppDbContext db = null;
        
        // BindProperty attribute indicates that the property will get 
        // its value from the model binding, at post
        [BindProperty]
        public Employee Employee { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public string Message { get; set; }
        public InsertModel(AppDbContext db)
        {
            this.db = db;
        }

        public void FillCountries()
        {
            List<SelectListItem> listOfCountries = (from c in db.Employees
                                                    select new SelectListItem()
                                                    {
                                                        Text = c.Country,
                                                        Value = c.Country
                                                    }).Distinct().ToList();

            Countries = listOfCountries;
        }

        public void OnGet()
        {
            FillCountries();
        }

        public void OnPost()
        {
            FillCountries();
            if(ModelState.IsValid)
            {
                try
                {
                    db.Employees.Add(Employee);
                    db.SaveChanges();
                    Message = "Employee Inserted Successfully";
                }
                catch (DbUpdateException ex1)
                {
                    Message = ex1.Message;
                    if(ex1.InnerException != null)
                    {
                        Message += ": " + ex1.InnerException.Message;
                    }
                }
                catch(Exception ex2)
                {
                    Message = ex2.Message;
                }
            }
        }
    }
}
