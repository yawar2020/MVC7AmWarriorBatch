using MVC7AmWarriorBatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC7AmWarriorBatch.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ViewResult Index() {

            // return View("~/Views/Employee/GetEmployee.cshtml");
            return View("Index");
        }
        public ViewResult Index1()
        {

            // return View("~/Views/Employee/GetEmployee.cshtml");
            return View();
        }
        public string GetHello(int? Empid) {
            return "Hello World Employee id "+Empid+" EmpName "+Request.QueryString["EmpName"]+" Designation "+Request.QueryString["Designation"];
        }

        public PartialViewResult GetData() {

            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel db = new EmployeeModel();

            db.Empid = 1;
            db.EmpName = "Govind";
            db.EmpSalary = 21000;

            EmployeeModel db1 = new EmployeeModel();
            db1.Empid = 2;
            db1.EmpName = "Supriya";
            db1.EmpSalary = 22000;

            EmployeeModel db2 = new EmployeeModel();
            db2.Empid = 3;
            db2.EmpName = "Naveen";
            db2.EmpSalary = 23000;

            dbobj.Add(db);
            dbobj.Add(db1);
            dbobj.Add(db2);

            ViewBag.Empinfo = dbobj;
            return PartialView("_mypartialView",dbobj);


        }

        public RedirectResult GetToPageUrl()
        {
            return Redirect("~/Default/Index?a=1");
        }

        public RedirectToRouteResult Tom()
        {
            return RedirectToRoute("Default1");
        }
        public ViewResult Jerry()
        {
            ViewBag.somedata = "Watch Online ";
            return View();
        }
        public JsonResult GetDataFromServer() {
            EmployeeModel db = new EmployeeModel();
            db.Empid = 1;
            db.EmpName = "james";
            db.EmpSalary = 3000;

            EmployeeModel db1 = new EmployeeModel();
            db1.Empid = 2;
            db1.EmpName = "peter";
            db1.EmpSalary = 4000;

            List<EmployeeModel> obj = new List<EmployeeModel>();
            obj.Add(db);
            obj.Add(db1);

            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        public FileResult GetFile()
        {
            return File("~/Web.config","application/xml","My Web config");
        }
        public ContentResult GetContent() {

            //return Content("Hello World");
            // return Content("<p style='color:green'>Hello World</p>");
            return Content("<script>alert('Hello World');</script>");
        }

        public ActionResult SetDataViewBag()
        {
            //ViewData["EmpName"] = "supriya";
            ViewBag.Empname = "Supriya";

            return RedirectToAction("GetDataViewBag");
        }
        public ActionResult GetDataViewBag()
        {
            ViewData["EmpName"] = "supriya";
            // string data=ViewData["EmpName"].ToString();
            // string data = ViewBag.Empname;
            return View();
        }

    }
}