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
        public int saveEmployeeDetails(EmployeModel obj)
        {
            SqlCommand cmd = new SqlCommand("sp_SaveEmployeeDetails_Warriors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpName",obj.EmpName );
            cmd.Parameters.AddWithValue("@EmpSalary", obj.EmpSalary);
            object i = cmd.ExecuteScalar();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
        public EmployeModel GetEmployeeDetailsById(int? id) {
            SqlCommand cmd = new SqlCommand("sp_GetEmployeeDetailById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeModel emp = new EmployeModel();
            
            foreach (DataRow dr in dt.Rows)
            {
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = Convert.ToString(dr[1]);
                emp.EmpSalary = Convert.ToInt32(dr[2]);
              
            }
            return emp;

        }

        
             public int UpdateEmployeeDetailsById(EmployeModel obj)
        {
            SqlCommand cmd = new SqlCommand("sp_UpdateEmployeeDetails_Warriors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Empid", obj.EmpId);
            cmd.Parameters.AddWithValue("@EmpName", obj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary", obj.EmpSalary);
            object i = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
    }
}