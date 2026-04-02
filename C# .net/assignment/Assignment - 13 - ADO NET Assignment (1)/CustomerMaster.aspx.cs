using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BookStoreLib;

public partial class CustomerMaster : System.Web.UI.Page
{
    SqlConnection con;
    public void inputFeildsEnable(bool b)
    {
        txtName.Enabled = b;
        txtPhno.Enabled = b;
        txtAddress.Enabled = b;
    }

    //refreshing the list
    public void RefreshCustIDList()
    {
        //command to fetch customer id from database
        SqlCommand cmd = new SqlCommand("select CustID from CustomerMaster order by CustID", con);

        SqlDataReader rdr = cmd.ExecuteReader();        
        //displaying all items in list
        CustIdDropDown.Items.Clear();
        while (rdr.Read())
        {
            CustIdDropDown.Items.Add(rdr[0].ToString());
        }
        CustIdDropDown.Items.Insert(0, "--Select id--");

        //unabling and disabling feilds and button
        #region
        inputFeildsEnable(false);
        btnAdd.Enabled = true;
        btnSave.Enabled = false;
        btnEdit.Enabled = false;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
        #endregion
        rdr.Close();
    }

    //method to validate entered mobile number
    public string MobileNoValidation(string phno)
    {
        //checking for null string null empty, or contains only whitespace
        if (string.IsNullOrWhiteSpace(phno))
        {
            throw new Exception("Phone number cannot be empty");
        }
        else if (phno.Length != 10)
        {
            throw new Exception("please enter the 10 digit phone number currectly");
        }
        else if (phno.All(c=>c>='0' && c<='9'))
        {
            //SqlCommand cmd = new SqlCommand("select MobileNumber")
            return phno;
        }
        else
        {
            throw new Exception("please enter valid phone no");
        }
    }

    //clearing all input feilds
    public void ClearInputFeilds()
    {
        txtCustId.Text = "";
        txtName.Text = "";
        txtPhno.Text = "";
        txtAddress.Text = "";
    }

    //======================================= button click ang pageload methods ================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //getting data sonnection
                con = DataConnection.GetDataConnection();
                con.Open();
                //refreshing the list
                RefreshCustIDList();
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
    }

    //displays the customer data based on id selected
    protected void CustIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (CustIdDropDown.Text == "--Select id--")
            {
                Response.Write("please select an id");
            }
            else
            {
                //geting the connection and turning it on
                con = DataConnection.GetDataConnection();
                con.Open();

                //fetching to get custumer details using customer id
                SqlCommand cmd = new SqlCommand("select * from CustomerMaster where CustID=@id", con);
                cmd.Parameters.AddWithValue("@id", CustIdDropDown.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                //displaying customer details
                while (rdr.Read())
                {
                    txtCustId.Text = rdr["CustID"].ToString();
                    txtName.Text = rdr["CustName"] == DBNull.Value ? "NULL" : rdr["CustName"].ToString(); ;
                    txtAddress.Text = rdr["CustAddress"] == DBNull.Value ? "NULL" : rdr["CustAddress"].ToString(); ;
                    txtPhno.Text = rdr["MobileNumber"].ToString();
                }
                rdr.Close();
                //unabling and disabling feilds and button
                #region
                inputFeildsEnable(false);
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = true;
                #endregion
            }
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            try
            {
                con.Close();
            }
            catch (Exception ex) { }
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //enabling feilds so that data can be updated and enabling and disabling the buttons
        btnDelete.Enabled = true;
        btnEdit.Enabled = false;
        btnUpdate.Enabled = true;
        btnSave.Enabled = false;

        inputFeildsEnable(true);
    }

    //button to udate the customer data
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Response.Write("name cannot be empty");
            }
            else
            {
                //getting the data connection an starting it
                con = DataConnection.GetDataConnection();
                con.Open();
                //creating command to execute on user input
                SqlCommand cmd = new SqlCommand("update CustomerMaster set CustName=@name, CustAddress=@address, MobileNumber=@mobileNo where CustID=@id", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobileNo", MobileNoValidation(txtPhno.Text));
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(txtCustId.Text));

                //executing the query and printing the result
                int result = cmd.ExecuteNonQuery();
                Response.Write(result > 0 ? "Updated successfully" : "updation unsuccessfull");
            }
        }
        catch (SqlException sqlEx)
        {
            Response.Write("please enter the different mobile number and Please check entered data");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    //clears the input feild and selects default id button;
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //clearing input feils so new data can be entered
            ClearInputFeilds();
            //selecting default value in customer id propdown
            CustIdDropDown.SelectedIndex = 0;
            //enabling input feilds to add the data
            inputFeildsEnable(true);
            //enabling and disabling the buttons
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //adds another customer to the database
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                Response.Write("name cannot be empty");
            }
            else
            {
                //getiing the connection and starting the connection
                con = DataConnection.GetDataConnection();
                con.Open();
                //creating a sql comment with connection to inser the data in customer master table
                SqlCommand cmd = new SqlCommand("insert into CustomerMaster values(@name,@address,@mobileNumber)", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobileNumber", MobileNoValidation(txtPhno.Text));

                //executing the command and checking the result
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    //refreshing custumed id list to add record succesfully
                    RefreshCustIDList();
                    Response.Write("record added successfully ");
                }
            }
        }
        catch (SqlException sqlEx)
        {
            Response.Write("please enter the different mobile number and Please check entered data");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    //deletes the customer data using id
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //getting connection and opening the connection
            con = DataConnection.GetDataConnection();
            con.Open();
            //command to delete the data from customer master table using customer idl;
            SqlCommand cmd = new SqlCommand("delete from CustomerMaster where CustID=@id", con);
            cmd.Parameters.AddWithValue("@id", CustIdDropDown.Text);
            //executing the command and checking the result
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Response.Write("data deleted successfully");
                RefreshCustIDList();
                ClearInputFeilds();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    //resents the buttons and feilds
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            con = DataConnection.GetDataConnection();
            con.Open();
            //reresh the idList and clear the input feilds
            RefreshCustIDList();
            ClearInputFeilds();
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}