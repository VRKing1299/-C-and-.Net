using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rdr;
    DataTable dt;

    public string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //creating the connection
                con = new SqlConnection(strCon);
                con.Open();

                //creating the command to 
                string command = "select * from Dept";
                cmd = new SqlCommand(command, con);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DropDownList1.Items.Add(rdr[0].ToString());
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
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //string strCon;
        try
        {
            //fetching the connection string
            //strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

            //creating connection
            con = new SqlConnection(strCon);
            //con.ConnectionString = strCon;
            con.Open();

            //writing the command / creating command 
            string command = "select * from Dept";
            cmd = new SqlCommand(command,con);
            //cmd = new SqlCommand();
            //cmd.CommandText = command;
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.Text;

            //executing the comand and fetching the data
            rdr = cmd.ExecuteReader();

            //cretating a table to load data in table format
            dt = new DataTable();
            dt.Load(rdr);

            //displaying the data table in the grid view
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con = new SqlConnection(strCon);
            con.Open();
            int deptId = Convert.ToInt16(DropDownList1.SelectedItem.Text);
            string command = "select * from Dept where DeptId=" + deptId;

            cmd = new SqlCommand(command, con);

            rdr = cmd.ExecuteReader();

            dt = new DataTable();
            dt.Load(rdr);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}