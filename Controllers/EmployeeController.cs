using Microsoft.AspNetCore.Mvc;
using EmployeeManagement2.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace EmployeeManagement2.Controllers
{
    public class EmployeeController : Controller
    {
        //public static ACE42023Context db = new ACE42023Context();
        private readonly ACE42023Context db;
        public EmployeeController(ACE42023Context _db)
        {
            db=_db;
        }
        public IActionResult ShowEmployee()
        {
            ViewBag.username=HttpContext.Session.GetString("username");
            if(ViewBag.username!=null)
            return View(db.SuneetEmployees);
           else return RedirectToAction("Login","Login");
            
            //return View(e);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SuneetEmployee er)
        {           
            db.SuneetEmployees.Add(er);
            db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult Details(int id)
        {
            SuneetEmployee emp=db.SuneetEmployees.Find(id);
            return View(emp);
            
        }
        public IActionResult Edit(int id)
        {
            SuneetEmployee emp=db.SuneetEmployees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(SuneetEmployee emp)
        {
            db.SuneetEmployees.Update(emp);
            db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult Delete(int id)
        {
            SuneetEmployee emp=db.SuneetEmployees.Find(id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            SuneetEmployee emp=db.SuneetEmployees.Find(id);
            db.SuneetEmployees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("ShowEmployee");
        }
        public IActionResult SearchProducts(IFormCollection f)
        {
            string keyword = f["keyword"].ToString();
            var result= db.SuneetEmployees.Where(x=> x.FirstName.Contains(keyword)).Select(x=>x).ToList();
            return View(result);


        }

        }
    }
