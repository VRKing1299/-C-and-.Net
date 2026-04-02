using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataConnectionLib;
using System.Data;
using System.Data.SqlClient;

public partial class DisplayBills : System.Web.UI.Page
{
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlDataReader rdr = null;
            try
            {
                con = DataConnection.GetDataConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select BillNo from BillingDetails", con);
                rdr = cmd.ExecuteReader();
                ProcudctIdDropDown.Items.Add("--select Id--");
                while (rdr.Read())
                {
                    ProcudctIdDropDown.Items.Add(rdr[0].ToString());
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
            }
        }
    }

    protected void ProcudctIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlDataReader rdr = null;
        try
        {
            if(ProcudctIdDropDown.Text== "--select Id--")
            {
                gvDisplayBill.Visible = false;
            }
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select b.BillNo,c.CustName,p.ProductName, b.BuyQuantity,b.TotalBill from BillingDetails b left outer join ProductMaster p on b.ProdID = p.ProdID left outer join CustomerMaster c on b.CustId = c.CustId where BillNo =@id ", con);
                cmd.Parameters.AddWithValue("@id", ProcudctIdDropDown.Text);
                rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rdr);
                gvDisplayBill.Visible = true;
                gvDisplayBill.DataSource = dt;
                gvDisplayBill.DataBind();
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
        }
    }
}