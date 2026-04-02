using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Order_Display : System.Web.UI.Page
{
    SqlConnection con;

    //method to refresh the billing id dropdown list
    public void RefreshOrderIdDropDownList()
    {
        //creating a command to fetch mobile number from customer
        SqlCommand cmd = new SqlCommand("select BillNo from BillDetails order by BillNo", con);
        SqlDataReader rdr = cmd.ExecuteReader();//executing the command
        //reading the data and inseting it
        OrderIdDropDown.Items.Clear();
        while (rdr.Read())
        {
            OrderIdDropDown.Items.Add(rdr[0].ToString());
        }
        //inserting a default value and selecting it
        OrderIdDropDown.Items.Insert(0, "-- select Bill no --");
        OrderIdDropDown.SelectedIndex = 0;
        rdr.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //getiing connection and amd connecting to data base
                con = DataConnection.GetDataConnection();
                con.Open();

                RefreshOrderIdDropDownList();
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
    }

    protected void OrderIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (OrderIdDropDown.Text == "-- select Bill no --")
            {
                gvBooksData.Visible = true;
            }
            else
            {
                //getting the connectiong and starting the connection
                con = DataConnection.GetDataConnection();
                con.Open();
                //command to fetch the particulat bill no
                SqlCommand cmd = new SqlCommand("select b.BillNo,c.CustName,p.ProdName,b.BuyQuantity,p.ProdPrice ,b.TotalBill from BillDetails b left outer join ProductMaster p on b.ProdID = p.ProdID left outer join CustomerMaster c on b.CustID = c.CustID where b.BillNo = @billNo", con);
                cmd.Parameters.AddWithValue("@billNo", OrderIdDropDown.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                gvBooksData.DataSource = dt;
                gvBooksData.DataBind();
                rdr.Close();
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