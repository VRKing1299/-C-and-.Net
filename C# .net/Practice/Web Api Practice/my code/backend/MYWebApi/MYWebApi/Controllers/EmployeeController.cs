using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MYWebApi.Models;

namespace MYWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        //this method is used to get the data from the employees
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>();
            //string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                string query = "select e.EmpId, e.EmpName,e.Salary, d.DeptName, e.DeptId from Employee e  inner join Dept d on e.DeptId = d.DeptId";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    emp.EmpName = rdr["EmpName"].ToString();
                    emp.Salary = Convert.ToDouble(rdr["Salary"]);
                    emp.DeptName = rdr["DeptName"].ToString();
                    emp.DeptId = Convert.ToInt32(rdr["DeptId"]);

                    empList.Add(emp);
                }
            }

            return empList;
        }

        //this method is used to inser the employee data
        [HttpPost]
        public string InserEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                string query = "insert into Employee values(@empName,@deptId,@sal)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@empName", emp.EmpName);
                cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
                cmd.Parameters.AddWithValue("@sal", emp.Salary);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "Employee Inserted Successsfully" : "Failed to insert employee";
            }
        }

        //this method is used to update employee data
        //[HttpPut]
        //public string UpdateEmployee(Employee emp)
        //{
        //    using(SqlConnection con = new SqlConnection(str))
        //    {
        //        string query = "update Employee set EmpName=@name, DeptId=@deptId, Salary=@sal where EmpId=@id";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@name", emp.EmpName);
        //        cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
        //        cmd.Parameters.AddWithValue("@sal", emp.Salary);
        //        cmd.Parameters.AddWithValue("@id", emp.EmpId);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    return "employee updated successfully";
        //}

        [HttpPut]
        public string UpdateEmployee(Employee emp, int id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                string query = "update Employee set EmpName=@name, DeptId=@deptId, Salary=@sal where EmpId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", emp.EmpName);
                cmd.Parameters.AddWithValue("@deptId", emp.DeptId);
                cmd.Parameters.AddWithValue("@sal", emp.Salary);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            return "employee updated successfully";
        }

        //this method is usded to delet the employee using the id
        [HttpDelete]
        public string DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                string query = "delete from Employee where EmpId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            return "Employee deleted successfully";
        }
    }
}
