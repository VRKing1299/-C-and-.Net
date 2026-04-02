using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataConnectionLib;
using System.Data;
using System.Data.SqlClient;

public partial class BillMaster : System.Web.UI.Page
{
    SqlConnection con;

    //comment to refresh the customer number dropdownlist
    public void RefreshCustNumberDropDown()
    {
        //command to get the mobile number of customer
        SqlCommand cmd = new SqlCommand("select MobileNumber from CustomerMaster", con);
        SqlDataReader rdr = cmd.ExecuteReader();

        //clearing the data of list adding a default value
        CustNumberDropDown.Items.Clear();
        CustNumberDropDown.Items.Add("-- select Customer Number --");
        //adding user data to the customernumber dropdown list
        while (rdr.Read())
        {
            CustNumberDropDown.Items.Add(rdr[0].ToString());
        }
        rdr.Close();
    }

    public void RefreshProductNameDropDown()
    {
        //command to get the mobile number of customer
        SqlCommand cmd = new SqlCommand("select ProductName from ProductMaster;", con);
        SqlDataReader rdr = cmd.ExecuteReader();

        //clearing the data of list adding a default value
        ProductNameDropDown.Items.Clear();
        ProductNameDropDown.Items.Add("-- select Product --");
        //adding user data to the customernumber dropdown list
        while (rdr.Read())
        {
            ProductNameDropDown.Items.Add(rdr[0].ToString());
        }
        rdr.Close();
    }

    //method to set feilds and labels to default
    public void SetDefaultQuantityPrice()
    {
        //disabling the feilds 
        #region
        btnBuy.Enabled = false;
        lblAvailableQuantity.Text = "0";
        lblPrice.Text = "0";
        lblTotalBill.Text = "0";
        txtBuyQuantity.Text = "";
        #endregion
    }

    //============================= page loads and events ======================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                con = DataConnection.GetDataConnection();
                con.Open();
                //fetching data for both the list
                RefreshCustNumberDropDown();
                RefreshProductNameDropDown();
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

    protected void CustNumberDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //making display table false
        gvCurrentBill.Visible = false;
    }

    protected void ProductNameDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvCurrentBill.Visible = false;
        if(ProductNameDropDown.Text== "-- select Product --")
        {
            //disabling the feilds 
            #region
            SetDefaultQuantityPrice();
            #endregion
        }
        else
        {
            SqlDataReader rdr = null;
            try
            {
                con = DataConnection.GetDataConnection();
                con.Open();
                //command to fetch quantity and price from database using product name
                SqlCommand cmd = new SqlCommand("select Quantitity,Price from ProductMaster where ProductName =@name", con);
                cmd.Parameters.AddWithValue("@name", ProductNameDropDown.Text);

                //executing the query and printing the data to ui
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblAvailableQuantity.Text = rdr[0].ToString();
                    lblPrice.Text = rdr[1].ToString();
                }


                //disableing the buy button and emplying the buy quantity
                //disabling the feilds 
                #region
                btnBuy.Enabled = false;
                lblTotalBill.Text = "0";
                txtBuyQuantity.Text = "";
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
                if (rdr != null && !rdr.IsClosed)
                {
                    rdr.Close();
                }
            }
        }
    }

    protected void txtBuyQuantity_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (ProductNameDropDown.Text == "-- select Product --") Response.Write("please select a product");
            else
            {
                //converitng values into int to compareit
                int buyQuant = Convert.ToInt32(txtBuyQuantity.Text);
                int currentQuant = Convert.ToInt32(lblAvailableQuantity.Text);
                int price = Convert.ToInt32(lblPrice.Text);
                //validating the input an printing output
                if (buyQuant <= 0)
                {
                    Response.Write("buy quantity cannot be smaller than 1");
                    btnBuy.Enabled = false;
                }
                else if (buyQuant > currentQuant)
                {
                    Response.Write("buy quantity cannot be greater than current quantity");
                    btnBuy.Enabled = false;
                }
                else
                {
                    lblTotalBill.Text = "" + (price * buyQuant);
                    btnBuy.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            btnBuy.Enabled = false;
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        SqlDataReader rdr = null;
        SqlDataReader rdr2 = null;
        try
        {
            if (CustNumberDropDown.Text == "-- select Customer Number --") Response.Write("please select customer number");
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();
                //fething quantity and id of product
                #region
                int quant = 0;
                int prodId = 0;
                SqlCommand fetchQuantID = new SqlCommand("select ProdID,Quantitity from ProductMaster where ProductName=@name", con);
                fetchQuantID.Parameters.AddWithValue("@name", ProductNameDropDown.Text);
                rdr = fetchQuantID.ExecuteReader();
                while (rdr.Read())
                {
                    prodId = Convert.ToInt32(rdr[0].ToString());
                    quant = Convert.ToInt32(rdr[1].ToString());
                }
                #endregion

                int buyQuant = Convert.ToInt32(txtBuyQuantity.Text);

                //final remaining quantity
                int finalQuant = quant - buyQuant;
                //fetching customer id
                #region
                SqlCommand fetchCustId = new SqlCommand("select CustId from CustomerMaster where MobileNumber=@number",con);
                fetchCustId.Parameters.AddWithValue("@number", CustNumberDropDown.Text);
                int custId = Convert.ToInt32(fetchCustId.ExecuteScalar());
                #endregion

                //inserting values into bliiling talbe
                #region
                SqlCommand cmd = new SqlCommand("insert into BillingDetails(CustId,ProdID,BuyQuantity,TotalBill) values(@custId,@productId,@buyQuant,@totalBill)", con);
                cmd.Parameters.AddWithValue("@custId", custId);
                cmd.Parameters.AddWithValue("@productId", prodId);
                cmd.Parameters.AddWithValue("@buyQuant", buyQuant);
                cmd.Parameters.AddWithValue("@totalBill", lblTotalBill.Text);
                #endregion
                int res = cmd.ExecuteNonQuery();
                Response.Write(res > 0 ? "Bill generated successfully" : " failed to generate bill");

                //updating quantity in product table
                SqlCommand updatProduct = new SqlCommand("update ProductMaster set Quantitity=@quant where ProdID=@pid", con);
                updatProduct.Parameters.AddWithValue("@quant", finalQuant);
                updatProduct.Parameters.AddWithValue("@pid", prodId);
                int result = updatProduct.ExecuteNonQuery();
                Response.Write(result > 0 ? "product updated" : "failed to update product");

                //setting every thing to default
                SetDefaultQuantityPrice();
                CustNumberDropDown.SelectedIndex = 0;
                ProductNameDropDown.SelectedIndex = 0;

                //displaying inserted bill
                SqlCommand fetchCurrentBill = new SqlCommand("select top 1 b.BillNo,c.CustName,p.ProductName, b.BuyQuantity,b.TotalBill from BillingDetails b left outer join ProductMaster p on b.ProdID = p.ProdID left outer join CustomerMaster c on b.CustId = c.CustId order by b.BillNo desc; ",con);
                rdr2 = fetchCurrentBill.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr2);
                gvCurrentBill.Visible = true;
                gvCurrentBill.DataSource = dt;
                gvCurrentBill.DataBind();

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
            if (rdr != null && !rdr.IsClosed)
            {
                rdr.Close();
            }
            if (rdr2 != null && !rdr2.IsClosed)
            {
                rdr2.Close();
            }
        }
    }
}
