using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager.Razor.Pages
{
    public class ErrorModel : PageModel
    {
        public string Code { get; set; }
        public void OnGet([FromQuery] int code)
        {
            if(code > 0)
            {
                Code = "Status Code: " + code;
            }
        }
    }
}
