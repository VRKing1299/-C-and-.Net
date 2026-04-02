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
    public void FeildsEnable(bool b = false)
    {

        txtName.Enabled = b;
        txtSalary.Enabled = b;
        DeptNameDropDown.Enabled = true;
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
            if (rdr != null)
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
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }


    protected void EmpIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FeildsEnable();
            //btnAdd.Enabled = true;
            //btnSave.Enabled = false;
            //btnEdit.Enabled = true;
            //btnUpdate.Enabled = false;

            con = GetConnection();
            con.Open();

            cmd = new SqlCommand("select * from Employee where empId = @id", con);
            int id = Convert.ToInt32(EmpIdDropDown.Text);

            //fetching the employee ad displaying the employee
            FetchEmpData(id);
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
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }


}