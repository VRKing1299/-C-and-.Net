using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataConnectionLib;
using System.Data;
using System.Data.SqlClient;

public partial class CustomerMaster : System.Web.UI.Page
{
    SqlConnection con;
    
    //method to refrest the id dropdownlist
    public void RefreshIdDropDownList()
    {
        SqlCommand cmd = new SqlCommand("select CustID from CustomerMaster",con);
        SqlDataReader rdr = cmd.ExecuteReader();

        CustIdDropDown.Items.Clear();
        CustIdDropDown.Items.Add("-- Select Id --");
        while (rdr.Read())
        {
            CustIdDropDown.Items.Add(rdr[0].ToString());
        }
        rdr.Close();
    }

    //method to cleare the input feilds
    public void ClearInputFeilds()
    {
        txtName.Text = "";
        txtAddress.Text = "";
        txtMobileNo.Text = "";
    }

    //method to enable and disable input feilds
    public void EnableInputFeilds(bool b)
    {
        txtAddress.Enabled = b;
        txtName.Enabled = b;
        txtMobileNo.Enabled = b;
    }
    
    //make button and feilds default 
    public void DefaultFeildsAndButton()
    {
        btnEditcust.Enabled = false;
        btnSaveCust.Enabled = false;
    }

    //code to validate phone number
    public bool ValidatePhNo(string str)
    {
        if (str.Length != 10)
        {
            Response.Write("Mobile No must have 10 digits");
            return false;
        }
        else if (str.Contains("-"))
        {
            Response.Write("Mobile No cannot be negative");
            return false;
        }
        else if (!str.All(c => c >= '0' && c <= '9'))
        {
            Response.Write("PLease enter valid mobile no");
            return false;
        }
        else return true;
    }

    //============================================ page load and button click events =======================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //connection to database
                con = DataConnection.GetDataConnection();
                con.Open();
                //fetching id in dropdown list
                RefreshIdDropDownList();
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
    }

    protected void CustIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(CustIdDropDown.Text== "-- Select Id --")
        {
            //makeing every thing default
            #region
            DefaultFeildsAndButton();
            ClearInputFeilds();
            EnableInputFeilds(true);
            btnUpdateCust.Enabled = false;
            #endregion
        }
        else
        {
            try
            {
                EnableInputFeilds(false);
                con = DataConnection.GetDataConnection();
                con.Open();

                //command to fetch customer detail based on customer id
                SqlCommand cmd = new SqlCommand("select * from CustomerMaster where CustID=@id", con);
                cmd.Parameters.AddWithValue("@id", CustIdDropDown.Text);
                SqlDataReader rdr = cmd.ExecuteReader();

                //displaying user details
                while (rdr.Read())
                {
                    txtName.Text = (rdr["CustName"].ToString());
                    txtAddress.Text = (rdr["CustAddress"].ToString());
                    txtMobileNo.Text = (rdr["MobileNumber"].ToString());
                }

                //enabling and disabling the buttons
                #region
                btnSaveCust.Enabled = false;
                btnUpdateCust.Enabled = false;
                btnEditcust.Enabled = true;
                #endregion
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
    }
    //button to edit the feilds 
    protected void btnEditcust_Click(object sender, EventArgs e)
    {
        EnableInputFeilds(true);
        btnUpdateCust.Enabled = true;
    }



    protected void btnUpdateCust_Click(object sender, EventArgs e)
    {
        try
        {
            //validating inputs
            if (string.IsNullOrWhiteSpace(txtName.Text)) Response.Write("Name connot be emplty");
            else if (string.IsNullOrWhiteSpace(txtAddress.Text)) Response.Write("address cannot be empty");
            else if (!ValidatePhNo(txtMobileNo.Text))  Response.Write("<br>Please correct it");
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();

                //command to update the customer data based on id
                #region
                SqlCommand cmd = new SqlCommand("update CustomerMaster set CustName=@name,CustAddress=@address,MobileNumber=@mobileNo where CustId=@id", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);
                cmd.Parameters.AddWithValue("@id", CustIdDropDown.Text);
                #endregion

                //executing the command
                int res = cmd.ExecuteNonQuery();
                Response.Write(res > 0 ? "Data has been Updated " : "Failed to updat the data");

                //enabliing and disablig the feilds and button
                EnableInputFeilds(false);
                btnUpdateCust.Enabled = false;

            }
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

    protected void btnAddCust_Click(object sender, EventArgs e)
    {
        //enabling feilds to add the data and disabling the other buttons
        ClearInputFeilds();
        EnableInputFeilds(true);
        btnEditcust.Enabled = false;
        btnUpdateCust.Enabled = false;
        CustIdDropDown.SelectedIndex = 0;
        btnSaveCust.Enabled = true;
    }

    protected void btnSaveCust_Click(object sender, EventArgs e)
    {
        try
        {
            //validating the user inputs
            if (string.IsNullOrWhiteSpace(txtName.Text)) Response.Write("Name connot be emplty");
            else if (string.IsNullOrWhiteSpace(txtAddress.Text)) Response.Write("address cannot be empty");
            else if (!ValidatePhNo(txtMobileNo.Text)) Response.Write("<br>Please correct it");
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();

                //command to insert the new constomer
                SqlCommand cmd = new SqlCommand("insert into CustomerMaster(CustName,CustAddress,MobileNumber) values(@name,@address,@mobileNo)", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobileNo", txtMobileNo.Text);

                //executing the command and printing the result;
                int res = cmd.ExecuteNonQuery();
                Response.Write(res > 0 ? "Customed added sucessfully" : "Error adding customer");

                //clearing the input feilds and disabling the input feilds
                RefreshIdDropDownList();
                ClearInputFeilds();
                EnableInputFeilds(false);
                btnSaveCust.Enabled = false;
            }
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

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            con = DataConnection.GetDataConnection();
            con.Open();
            RefreshIdDropDownList();
            ClearInputFeilds();
            EnableInputFeilds(false);
            btnSaveCust.Enabled = false;
            btnUpdateCust.Enabled = false;
            CustIdDropDown.SelectedIndex = 0;
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
}