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
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            EmployeModel obj = db.GetEmployeeDetailsById(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(EmployeModel e)
        {
           int i=db.UpdateEmployeeDetailsById(e);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(e);

            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeModel obj = db.GetEmployeeDetailsById(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ? id)
        {
            int i = db.DeleteEmployeeDetailsById(id);
            if (i > 0)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View();

            }
        }

        public ActionResult sendData() {

            ViewData["Student"] = "Supriya";
            return RedirectToAction("getData");
        }
        public ActionResult getData() {
          string s=  ViewData["Student"].ToString();
            return View();
        }
    }
}