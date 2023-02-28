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
    public class RegisterController: Controller  
    {  
        private readonly ACE42023Context db;
        private readonly ISession session;
        public RegisterController(ACE42023Context _db,IHttpContextAccessor httpContextAccessor)
        {
            db=_db;
            session=httpContextAccessor.HttpContext.Session;
        }
        public ActionResult Register(){return View(); }
        [HttpPost]
        public IActionResult Register(DakshUser u)
        {
            //var result=(from i in db.SuneetUsers where i.Username==u.Username && i.Userpassword==u.Userpassword select i).SingleOrDefault();
            db.DakshUsers.Add(u);
            HttpContext.Session.SetString("username",u.Username);
            return RedirectToAction("ShowEmployee", "Employee");
            
        }
    }
}