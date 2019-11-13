using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC7AmWarriorBatch.Models;
namespace MVC7AmWarriorBatch.Controllers
{
    public class EmployeeController : Controller
    {
        GaneshEntities db = new GaneshEntities();
        // GET: Employee
        public ViewResult GetEmployee()
        {
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
            return View(dbobj);
        }
        public ActionResult HtmlHelperExample()
        {
            ViewBag.Department = new SelectList(db.DepartmentModels, "DeptId", "DeptName",4);
            return View();
        }
    }
}