using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    DataSet ds;
    SqlDataReader rdr;
    SqlCommand cmd;

    //to create sql connection
    public SqlConnection GetConnection()
    {
        string conn = ConfigurationManager.ConnectionStrings["MYCon"].ConnectionString;
        return new SqlConnection(conn);
    }

    //disabling and unabling the feilds
    public void FeildsEnable(bool b=false)
    {
        
        txtName.Enabled = b;
        txtSalary.Enabled = b;
        DeptNameDropDown.Enabled = b;
    }

    //fetchig department id based on department name
    public object FetchDeptIdOnName()
    {
        //fetching dept id based on dept name 
        cmd = new SqlCommand("select DeptId from Dept where DeptName = @deptName", con);
        cmd.Parameters.Add("@deptName", DeptNameDropDown.Text);
        object deptId = cmd.ExecuteScalar();
        return deptId;
    }

    //
    public void ClearFeilds()
    {
        txtEmpId.Text = "";
        txtName.Text = "";
        txtSalary.Text = "";
    }

    //code to refresh the list
    public void RefreshIdList()
    {
        EmpIdDropDown.Items.Clear();
        cmd = new SqlCommand("select EmpId from Employee", con);

        rdr = cmd.ExecuteReader();

        //adding the datat to the  drop down
        while (rdr.Read())
        {
            EmpIdDropDown.Items.Add(rdr[0].ToString());
        }
        rdr.Close();
    }

    //displaying the department name in drop down list
    public void DiplayDeptNames()
    {
        //creating an sql command to fetch dept name from dept table and executing it
        cmd = new SqlCommand("select DeptName from Dept", con);
        rdr = cmd.ExecuteReader();

        //displaying it in dept name drop down
        while (rdr.Read())
        {
            DeptNameDropDown.Items.Add(rdr[0].ToString());
        }
    }

    //fetch the employee data
    public void FetchEmpData(int id)
    {
        try
        {
            cmd = new SqlCommand("select * from Employee where EmpID = @id ", con);
            cmd.Parameters.AddWithValue("@id", id);

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //fetching the dept name
                SqlCommand cmd2 = new SqlCommand("select DeptName from Dept where DeptId = @deptId", con);
                cmd2.Parameters.AddWithValue("@deptId", rdr["DeptId"]);
                object deptName = cmd2.ExecuteScalar();//for single value data

                DeptNameDropDown.Items.Clear();
                //DeptNameDropDown.Items.Add(deptName.ToString());//printing the dept name
                DeptNameDropDown.Items.Add((string)deptName);

                txtEmpId.Text = rdr["EmpId"].ToString();
                txtName.Text = rdr["EmpName"].ToString();
                txtSalary.Text = rdr.IsDBNull(rdr.GetOrdinal("Salary")) ? "NULL" : rdr["Salary"].ToString();
            }
        }
        finally
        {
            if(rdr != null)
            {
                rdr.Close();
            }
        }
    }

    //buttons and page load methods ===================================================

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                con = GetConnection();
                con.Open();
                //printing the list
                RefreshIdList();

                //disabling the feilds
                FeildsEnable();
                FetchEmpData(Convert.ToInt32(EmpIdDropDown.Text));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch(Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //enabling the feilds and emplying them
            FeildsEnable(true);
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            ClearFeilds();

            //displaying the names of department using function
            con = GetConnection();
            con.Open();

            DeptNameDropDown.Items.Clear();
            DiplayDeptNames();

            //enabling save button and disabling add button
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }


    //btn to edit existing data
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            //undabling the update button and feilds
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            FeildsEnable(true);

            //getting connection object and starting the connection
            con = GetConnection();
            con.Open();

            //function to add department names to the list;
            string deptName = DeptNameDropDown.Text;
            DiplayDeptNames();

            //diabling the edit button
            btnEdit.Enabled = false;

        }
        catch (Exception ex)
        {
            btnUpdate.Enabled = false;
            FeildsEnable();
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                rdr.Close();
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            con = GetConnection();
            con.Open();

            object deptId = FetchDeptIdOnName();

            //updating the employee details using employee id
            cmd = new SqlCommand("update Employee set EmpName =@name, DeptId = @deptId, Salary = @sal where EmpId = @empId",con);
            cmd.Parameters.Add("@empId", EmpIdDropDown.Text);
            cmd.Parameters.Add("@name", txtName.Text);
            cmd.Parameters.Add("@deptId", deptId);
            int sal = Convert.ToInt32(txtSalary.Text);
            if (sal < 0) throw new Exception("salary cannot be negative"); //new ArgumentException("salary cannot be negative");
            cmd.Parameters.Add("@sal", sal);

            //executing the query and printing the result
            int result = cmd.ExecuteNonQuery();
            Response.Write(result > 0 ? "updated successfully" : "Update Unsuccessfull");

            //enabling the edit button and disabling the feilds
            btnEdit.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            FeildsEnable();
            
        }
        catch (Exception ex)
        {
            Response.Write("please enter valid data <br>");
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }catch(Exception exp)
            {
                Response.Write(exp.Message);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //getiing connection and staring the connection
            con = GetConnection();
            con.Open();

            object deptid = FetchDeptIdOnName();

            //adding the employee to the database
            cmd = new SqlCommand("insert into Employee values (@empName,@deptId,@sal)", con);
            cmd.Parameters.Add("@empName", txtName.Text);
            cmd.Parameters.Add("@deptId", deptid);
            int sal = Convert.ToInt32(txtSalary.Text);
            if (sal < 0) throw new ArgumentException("salary cannot be negative");
            cmd.Parameters.Add("@sal",sal);

            //executing the query and checking and printing the result
            int result = cmd.ExecuteNonQuery();
            Response.Write(result > 0 ? "Employee added successfully" : "Usucessfull");

            //enablig add button and disabling the save button
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            FeildsEnable();
            RefreshIdList();//refreshing the list
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //getting the connection
            con = GetConnection();
            con.Open();
            

            //query for deleting employee based on employee id
            cmd = new SqlCommand("delete from Employee where empId = @id", con);
            cmd.Parameters.Add("@id", EmpIdDropDown.Text);

            //executing the query and printing the result
            int result = cmd.ExecuteNonQuery();
            Response.Write(result > 0 ? "employee deleted sucessfully" : "error deleting employee");

            RefreshIdList();//refreahing the list
            ClearFeilds();//clearing the feilds
            FetchEmpData(Convert.ToInt32(EmpIdDropDown.Text));
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void EmpIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FeildsEnable();
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnUpdate.Enabled = false;

            con = GetConnection();
            con.Open();

            cmd = new SqlCommand("select * from Employee where empId = @id", con);
            int id = Convert.ToInt32(EmpIdDropDown.Text);

            //fetching the employee ad displaying the employee
            FetchEmpData(id);
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        con = GetConnection();
        con.Open();
        FeildsEnable();
        btnAdd.Enabled = true;
        btnSave.Enabled = false;
        btnEdit.Enabled = true;
        btnUpdate.Enabled = false;

        DeptNameDropDown.Items.Clear();
        RefreshIdList();
        FetchEmpData(Convert.ToInt32(EmpIdDropDown.Text));
    }
}