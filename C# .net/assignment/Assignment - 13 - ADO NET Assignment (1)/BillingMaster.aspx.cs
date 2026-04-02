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

public partial class BillingMaster : System.Web.UI.Page
{
    SqlConnection con;

    //code to refresh the customer phone no dropdown list
    public void RefreshCustomerPhNoDropDownList()
    {
        //creating a command to fetch mobile number from customer
        SqlCommand cmd = new SqlCommand("select MobileNumber from CustomerMaster order by MobileNumber", con);
        SqlDataReader rdr = cmd.ExecuteReader();//executing the command
        //reading the data and inseting it
        CustomerPhNoDropDown.Items.Clear();
        while (rdr.Read())
        {
            CustomerPhNoDropDown.Items.Add(rdr[0].ToString());
        }
        //inserting a default value and selecting it
        CustomerPhNoDropDown.Items.Insert(0, "-- select PhNo --");
        CustomerPhNoDropDown.SelectedIndex = 0;
        rdr.Close();
    }

    //method to refresh the book name dropdown list
    public void RefrestBookNameDropDownList()
    {
        //creating a command to fetch mobile number from customer
        SqlCommand cmd = new SqlCommand("select ProdName from ProductMaster order by ProdName", con);
        //executing the command
        SqlDataReader rdr = cmd.ExecuteReader();
        //reading the data and inseting it
        BookNameDropDown.Items.Clear();
        while (rdr.Read())
        {
            BookNameDropDown.Items.Add(rdr[0].ToString());
        }
        //inserting a default value and selecting it
        BookNameDropDown.Items.Insert(0, "-- select Book Name --");
        BookNameDropDown.SelectedIndex = 0;
        rdr.Close();
    }

    //clearing input and eselected feild
    public void ClearInputFeilds()
    {
        txtPurchaseQuant.Text = "";
        txtBillId.Text = "";
    }

    //function to check the quantity
    public string CheckBuyQuant(string quant)
    {
        if (string.IsNullOrWhiteSpace(quant))
        {
            throw new Exception("quantity cannot be empty");
        }
        else if (quant == "0")
        {
            throw new Exception("Buy quantity cannot be zero");
        }
        else if (!quant.All(c => c >= '0' && c <= '9'))
        {
            throw new Exception("quantity cannot be negative or alphabets");
        }
        else if (Convert.ToInt32(quant) > Convert.ToInt32(lblProdQuantity.Text))
        {
            throw new Exception("Buy Quantity is greater than Product in Inventery");
        }
        else
        {
            return quant;
        }
    }

    //resent every label and feilds
    public void ResetLabelsAndFeilds()
    {
        ClearInputFeilds();
        BookNameDropDown.SelectedIndex = 0;
        CustomerPhNoDropDown.SelectedIndex = 0;
        lblProdQuantity.Text = "0";
        lblPrice.Text = "0";
        lblPurchaseQuant.Text = "0";
        lblTotalPrice.Text = "";
        btnSave.Enabled = false;
    }

    //============================================= page load and other events ===============================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //getiing connection and amd connecting to data base
                con = DataConnection.GetDataConnection();
                con.Open();
                //gettind data frome each list
                RefreshCustomerPhNoDropDownList();
                RefrestBookNameDropDownList();
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
                }catch(Exception ex) { }
            }
        }
    }

    protected void CustomerPhNoDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BookNameDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //checking fro default value
            if (BookNameDropDown.Text == "-- select Book Name --")
            {
                lblProdQuantity.Text = "";
                lblPrice.Text = "";
            }
            else
            {
                //getting data connection
                con = DataConnection.GetDataConnection();
                con.Open();
                //command to fetch quantity and price of book from database
                SqlCommand cmd = new SqlCommand("select ProdQuantity,ProdPrice from ProductMaster where ProdName=@name", con);
                cmd.Parameters.AddWithValue("@name", BookNameDropDown.Text);
                //executing the command and showing the results
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblProdQuantity.Text = rdr[0].ToString();
                    lblPrice.Text = rdr[1].ToString();
                }
                btnSave.Enabled = false;
                rdr.Close();
            }

        }catch(Exception ex)
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

    //button to add new bill
    protected void btnNewBill_Click(object sender, EventArgs e)
    {
        //making everything default so new bill can be added
        ResetLabelsAndFeilds();
    }

    //button to save the bill
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (BookNameDropDown.Text == "-- select Book Name --")
            {
                Response.Write("Please select a book name ");
            }
            else if (CustomerPhNoDropDown.Text == "-- select PhNo --")
            {
                Response.Write("Please select the customer phone no ");
            }
            else
            {
                #region
                int currentQuant = Convert.ToInt32(lblProdQuantity.Text);
                int purchaseQuant = Convert.ToInt32(lblPurchaseQuant.Text);
                string finalQuant = "" + (currentQuant - purchaseQuant);

                con = DataConnection.GetDataConnection();
                con.Open();

                //command to fetch customer id based on phone no
                SqlCommand cmd1 = new SqlCommand("select CustID from CustomerMaster where MobileNumber = @phno", con);
                cmd1.Parameters.AddWithValue("@phno", CustomerPhNoDropDown.Text);
                string custId = Convert.ToString(cmd1.ExecuteScalar());

                //command to fetch book id based on book name
                #region
                SqlCommand cmd2 = new SqlCommand("select ProdID from ProductMaster where ProdName = @name", con);
                cmd2.Parameters.AddWithValue("@name", BookNameDropDown.Text);
                string bookId = Convert.ToString(cmd2.ExecuteScalar());
                #endregion

                //command to insert values into bill table
                #region
                SqlCommand cmd = new SqlCommand("insert into BillDetails values(@CustId,@ProdId,@buyQuant,@totalbill)", con);
                cmd.Parameters.AddWithValue("@CustId", custId);
                cmd.Parameters.AddWithValue("@ProdId", bookId);
                cmd.Parameters.AddWithValue("@buyQuant", lblPurchaseQuant.Text);
                cmd.Parameters.AddWithValue("@totalbill", lblTotalPrice.Text);
                int addBill = cmd.ExecuteNonQuery();
                #endregion

                //command to update the quantity of books in inventery
                #region
                SqlCommand cmd3 = new SqlCommand("update ProductMaster set ProdQuantity=@quant where ProdID=@id", con);
                cmd3.Parameters.AddWithValue("@quant", finalQuant);
                cmd3.Parameters.AddWithValue("@id", bookId);
                int updateProd = cmd3.ExecuteNonQuery();
                #endregion

                //printing the results
                Response.Write(addBill > 0 ? "bill generated successfully <br>" : " error generating bill<br>");
                Response.Write(updateProd > 0 ? "product quantity updated " : "Failed to update product quantity");

                //command to fetch and display just added bill
                SqlCommand cmd4 = new SqlCommand("select b.BillNo,c.CustName,p.ProdName,b.BuyQuantity,p.ProdPrice ,b.TotalBill from BillDetails b left outer join ProductMaster p on b.ProdID = p.ProdID left outer join CustomerMaster c on b.CustID = c.CustID where b.BillNo =(select max(b1.BillNo) from BillDetails b1)",con);
                SqlDataReader rdr = cmd4.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                gvBooksData.DataSource = dt;
                gvBooksData.DataBind();
                #endregion

                //resent ing every feilds and labels
                ResetLabelsAndFeilds();
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
        }
        
    }


    protected void txtPurchaseQuant_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            //checking for quentanty
            int purchaseQuant = Convert.ToInt32(CheckBuyQuant(txtPurchaseQuant.Text));
            int price = Convert.ToInt32(lblPrice.Text);

            //printing total quantity
            lblPurchaseQuant.Text = "" + purchaseQuant;

            //printing total price
            lblTotalPrice.Text = "" + (purchaseQuant * price);

            //unabling save button to save the bill
            btnSave.Enabled = true;
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}