using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataConnectionLib;
using System.Data;
using System.Data.SqlClient;

public partial class ProductMasterUI : System.Web.UI.Page
{
    //global cariable to pass the connection
    SqlConnection con;

    //code to refresh the product id drop down list
    public void RefreshProductIdDropdown()
    {
        #region
        //command to fetch id from table
        SqlCommand cmd = new SqlCommand("select ProdID from ProductMaster order by ProdID", con);
        SqlDataReader rdr = cmd.ExecuteReader();
        ProductIdDropDown.Items.Clear();//clearing previous list to add new value
        ProductIdDropDown.Items.Add("-- Select Product Id --");//adding a default value
        while (rdr.Read())//adding the data to the list from rdr,result set
        {
            ProductIdDropDown.Items.Add(rdr[0].ToString());
        }
        rdr.Close();
        #endregion
    }

    //clearing the input feilds
    public void ClearInputFeilds()
    {
        txtName.Text = "";
        txtPrice.Text = "";
        txtQuant.Text = "";
        txtUpdateQuantity.Text = "";
    }

    //method to making input feilds editable and unatitable
    public void EnableInputFeilds(bool b)
    {
        txtName.Enabled = b;
        txtPrice.Enabled = b;
    }
    //method to make edit quantity button editable and undditable
    public void AddEditQuant(bool b)
    {
        btnAdd.Visible = b;
        btnSub.Visible = b;
        txtUpdateQuantity.Visible = b;
    }

    //name validation 
    public bool ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //validating price
    public bool ValidatePrice(int price)
    {
        if (price < 0)
        {
            return false;
        }
        else return true;
    }

    //validating quantity
    public bool ValidateQuantity(int quant)
    {
        if (quant < 0)
        {
            return false;
        }
        else return true;
    }

    public void Default()
    {
        ClearInputFeilds();
        btnSave.Enabled = false;
        btnEdit.Enabled = false;
        btnUpdate.Enabled = false;
        btnAdd.Visible = false;
        btnSub.Visible = false;
        txtUpdateQuantity.Visible = false;
        EnableInputFeilds(true);
        txtQuant.Enabled = true;
    }

    //================================================== page load and button click events ====================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                #region
                //creating the connection
                con = DataConnection.GetDataConnection();
                con.Open();
                //displaying dropdown list
                RefreshProductIdDropdown();
                #endregion
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if(con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }

    protected void ProductIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader rdr =null;
        try
        {
            //if selected iteem is drop down item
            if (ProductIdDropDown.Text == "-- Select Product Id --")
            {
                #region
                Default();
                #endregion
            }
            else
            {
                EnableInputFeilds(false);//enabling input feilds
                con = DataConnection.GetDataConnection();
                con.Open();
                //command to fetch product details from id
                SqlCommand cmd = new SqlCommand("select * from ProductMaster where ProdID = @id", con);
                cmd.Parameters.AddWithValue("@id", ProductIdDropDown.Text);
                //executing the command
                rdr = cmd.ExecuteReader();
                //adding data to text box
                while (rdr.Read())
                {
                    #region
                    txtName.Text = rdr["ProductName"].ToString();
                    txtPrice.Text = rdr["Price"].ToString();
                    txtQuant.Text = rdr["Quantitity"].ToString();
                    #endregion
                }
                rdr.Close();

                //enablind and disabling the buttons
                #region
                txtQuant.Enabled = false;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                AddEditQuant(false);
                btnDelete.Enabled = true;
                #endregion
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if(rdr != null && !rdr.IsClosed)
            {
                rdr.Close();
            }
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            //enabling and disabling the feilds and buttons
            #region
            AddEditQuant(true);
            EnableInputFeilds(true);
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            txtQuant.Enabled = false;
            btnEdit.Enabled = false;
            #endregion
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //button to add quantity to current quantity
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            int currentQuant = Convert.ToInt32(txtQuant.Text);
            int editQuant = Convert.ToInt32(txtUpdateQuantity.Text);
            if (editQuant < 0)//checking if quantity is in negative
            {
                Response.Write(" quantity cannot be negative ");
            }
            else
            {
                //adding quantity
                txtQuant.Text = "" + (currentQuant + editQuant);
            }
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    //subtract wuantity to the current quantity
    protected void btnSub_Click(object sender, EventArgs e)
    {
        try
        {
            int currentQuant = Convert.ToInt32(txtQuant.Text);
            int editQuant = Convert.ToInt32(txtUpdateQuantity.Text);
            if (editQuant < 0)//checking for negative quantity
            {
                Response.Write(" quantity cannot be negative ");
            }
            else if (editQuant > currentQuant) Response.Write("cannot reomove more than current quantity");
            else
            {
                //subtracting quantity
                txtQuant.Text = "" + (currentQuant - editQuant);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    //method to updat the product
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            if (!ValidatePrice(Convert.ToInt32(txtPrice.Text)))
            {
                Response.Write("price cannot be negative ");
            }
            else if(!ValidateName(txtName.Text)) Response.Write("name cannot be null");
            else if(!ValidateQuantity(Convert.ToInt32(txtQuant.Text))) Response.Write("quantity cannot be negative");
            else
            {
                //getting connection turing it on
                con = DataConnection.GetDataConnection();
                con.Open();
                //crating command to updat the product usin id
                #region
                SqlCommand cmd = new SqlCommand("update ProductMaster set ProductName=@name, Price=@price, Quantitity=@quant where ProdID=@id", con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@quant", txtQuant.Text);
                cmd.Parameters.AddWithValue("@id", ProductIdDropDown.Text);
                #endregion

                //executing the command
                int result = cmd.ExecuteNonQuery();
                Response.Write(result > 0 ? "Record has been updated" : "failed to update the record");

                //enablinga and disabling the feilds
                #region
                AddEditQuant(false);
                EnableInputFeilds(false);
                btnUpdate.Enabled = false;
                #endregion
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

    protected void btnAddNewProduct_Click(object sender, EventArgs e)
    {
        try
        {
            //clearing the feilds and unabling the feilds for being able to add data
            ClearInputFeilds();
            EnableInputFeilds(true);
            ProductIdDropDown.SelectedIndex = 0;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            txtQuant.Enabled = true;
            AddEditQuant(false);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (!ValidatePrice(Convert.ToInt32(txtPrice.Text)))
            {
                Response.Write("price cannot be negative ");
            }
            else if (!ValidateName(txtName.Text)) Response.Write("name cannot be null");
            else if (!ValidateQuantity(Convert.ToInt32(txtQuant.Text))) Response.Write("quantity cannot be negative");
            else
            {
                //getting data connection and stating it
                con = DataConnection.GetDataConnection();
                con.Open();

                //command to add product
                SqlCommand cmd = new SqlCommand("insert into ProductMaster values(@name,@price,@quantity)",con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@quantity", txtQuant.Text);

                //executing the query and printing the result
                int res = cmd.ExecuteNonQuery();
                Response.Write(res > 0 ? "record added successfully" : "failded to add record");

                //enabling and disabling the buttons and feilds
                #region
                RefreshProductIdDropdown();
                btnSave.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                ClearInputFeilds();
                EnableInputFeilds(false);
                #endregion
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            con = DataConnection.GetDataConnection();
            con.Open();
            Default();
            RefreshProductIdDropdown();
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (ProductIdDropDown.Text== "-- Select Product Id --")
            {
                Response.Write("Please select the id ");
            }
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();

                //command to delete the product
                SqlCommand cmd = new SqlCommand("delete from ProductMaster where ProdID=@id", con);
                cmd.Parameters.AddWithValue("@id", ProductIdDropDown.Text);
                //printing the result
                int res = cmd.ExecuteNonQuery();
                Response.Write(res > 0 ? "record deleted successfully" : "failded to delete product");
                Default();
                RefreshProductIdDropdown();
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
}