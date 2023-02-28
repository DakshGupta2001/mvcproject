using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement2.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement2.Controllers  
{  
    public class LoginController: Controller  
    {  
        private readonly ACE42023Context db;
        private readonly ISession session;
        public LoginController(ACE42023Context _db,IHttpContextAccessor httpContextAccessor)
        {
            db=_db;
            session=httpContextAccessor.HttpContext.Session;
        }
        public ActionResult Login(){return View(); }
        [HttpPost]
        public IActionResult Login(DakshUser u)
        {
            var result=(from i in db.DakshUsers where i.Username==u.Username && i.Userpassword==u.Userpassword select i).SingleOrDefault();
            if(result !=null)
            {
                HttpContext.Session.SetString("username",result.Username);
                return RedirectToAction("ShowEmployee", "Employee");
                
            }
            else 
            {
                return View();
            }

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Login");
        }
        
    }  
}  