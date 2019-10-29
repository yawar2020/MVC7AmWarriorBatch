using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace Ado.net_approach.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        public List<EmployeModel> GetEmployeeDetails() {
            SqlCommand cmd = new SqlCommand("sp_GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EmployeModel> list = new List<EmployeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeModel emp = new EmployeModel();
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                list.Add(emp);
            }
            return list;
        }
    }
}