using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVC7AmWarriorBatch.Models
{
    public class EmployeeModel
    {
        public int Empid { get; set; }
        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }
}