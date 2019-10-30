using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ado.net_approach.Models;
namespace Ado.net_approach.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.GetEmployeeDetails());
        }
        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeModel emp)
        {
            int i = db.saveEmployeeDetails(emp);
            if (i > 0) {
                return RedirectToAction("index");
            }
            else
            {
                return View();

            }
        }
    }
}