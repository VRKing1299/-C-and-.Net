using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BookStoreManagementLib;
using BookStoreManagementLib.DataServiceMethods;
using BookStoreManagementLib.Services;
using BookStoreManagementLib.Models;

public partial class AllBooksData : System.Web.UI.Page
{
    //enabling and disabling input feilds 
    public void EnableInputFeilds(bool enable)
    {
        txtName.Enabled = enable;
        txtPrice.Enabled = enable;
        txtQuantity.Enabled = enable;
    }

    public void RefreshDataTable(SqlDataReader rdr)
    {
        DataTable dt = new DataTable();
        dt.Load(rdr);   // Load reader data once

        //Bind to GridView
        gvBooksData.DataSource = dt;
        gvBooksData.DataBind();

        //adding items to list
        BookIdDropDown.DataSource = dt;
        BookIdDropDown.DataTextField = "ProdID";
        BookIdDropDown.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                //connecting to the data base
                using (SqlConnection con = DataConnection.GetDataConnection())
                {
                    //starting the connetion
                    con.Open();

                    //creating object of service method
                    BookServices bookService = new BookServices(con);
                    //getting all book details from the books data
                    using (SqlDataReader rdr = bookService.GetAllBooksData())
                    {
                        RefreshDataTable(rdr);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void btnGetAllBooksData_Click(object sender, EventArgs e)
    {
        
    }

    protected void BookIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = DataConnection.GetDataConnection())
        {
            con.Open();
            BookServices bookService = new BookServices(con);
            Book book= bookService.GetBookById(Convert.ToInt32(BookIdDropDown.Text));
            txtBookId.Text = ""+book.BookId;
            txtName.Text = "" + book.BookName;
            txtPrice.Text = "" + book.BookPrice;
            lblAvailabelQuant.Text = "" + book.BookQuantity;
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        EnableInputFeilds(true);
        btnEdit.Enabled = false;
        btnUpdate.Enabled = true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Book book = new Book(Convert.ToInt32(BookIdDropDown.Text));
    }
}