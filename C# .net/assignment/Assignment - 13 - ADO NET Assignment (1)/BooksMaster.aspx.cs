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

public partial class BooksMaster : System.Web.UI.Page
{
    SqlConnection con;
    //=============================== custome methods ===========================
    //retuns all books from database
    public SqlDataReader GetAllBooksData()
    {
        SqlCommand cmd = new SqlCommand("select ProdID from ProductMaster", con);
        return cmd.ExecuteReader();
    }

    //clearing the feilds
    public void ClearInputFields()
    {
        txtBookId.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";
        lblAvailabelQuant.Text = "0";
    }

    //unabling name price and quantity feilds
    public void EnableInputFeilds(bool enable)
    {
        txtName.Enabled = enable;
        txtPrice.Enabled = enable;
        txtQuantity.Enabled = enable;
    }

    //making add and subtract quantity visible;
    public void QuantityAddSubFeildsVisible(bool b)
    {
        txtQuantity.Visible = b;
        btnAddQuant.Visible = b;
        btnSubtractQuant.Visible = b;
    }

    //code to refresh the id list
    public void RefreshBookIdList()
    {
        SqlDataReader rdr = GetAllBooksData();//gets all book data
                                              //adding items to list
        BookIdDropDown.Items.Clear();
        while (rdr.Read())
        {
            BookIdDropDown.Items.Add(rdr[0].ToString());
        }
        BookIdDropDown.Items.Insert(0,"--select id  --");

        //diabling feilds and buttons
        btnEdit.Enabled = false;
        btnUpdate.Enabled = false;
        btnSave.Enabled = false;
        btnDelete.Enabled = false;
        EnableInputFeilds(false);
        QuantityAddSubFeildsVisible(false);
        ClearInputFields();//clearing the input feilds
        rdr.Close();
    }

    //check for negative price
    public double PriceCheck(double price)
    {
        if (price < 0) throw new Exception("price cannot be negative");
        else return price;
    }

    public void BookNameCheck(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new Exception("book Name Cannt be Empty");
    }

    //============================== Buttons and Page load =========================================

    //page load code
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
               con = DataConnection.GetDataConnection();
               con.Open();
               RefreshBookIdList();//printing all book data
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                con.Close();
            }
        }

    }

    //function to fetch and display the book data based on index in dropdown
    protected void BookIdDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //checking for selected item from list
            if(BookIdDropDown.Text=="--select id  --")
            {
                Response.Write("please select valid id ");
            }
            else
            {
                con = DataConnection.GetDataConnection();
                con.Open();

                //getting book by id from book id drop down list 
                SqlCommand cmd = new SqlCommand("select * from ProductMaster where ProdID = @id", con);
                cmd.Parameters.AddWithValue("@id", BookIdDropDown.Text);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtBookId.Text = rdr["ProdID"].ToString();
                    txtName.Text = rdr["ProdName"].ToString();
                    txtPrice.Text = rdr["ProdPrice"].ToString();
                    lblAvailabelQuant.Text = rdr["ProdQuantity"].ToString();
                }
                rdr.Close();

                //unablind and diabling the input feilds and buttons
                btnEdit.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                EnableInputFeilds(false);
                QuantityAddSubFeildsVisible(false);
            }
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

    //function that unables us to updat the book information
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        //unabliling few feild for makind data editable
        EnableInputFeilds(true);
        QuantityAddSubFeildsVisible(true);
        btnEdit.Enabled = false;
        btnUpdate.Enabled = true;
    }

    //function to updat the current book information
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            con = DataConnection.GetDataConnection();
            con.Open();

            //updating book data by id
            SqlCommand cmd = new SqlCommand("update ProductMaster set ProdName=@name, ProdPrice=@price, ProdQuantity=@quant where ProdID=@id", con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", PriceCheck(Convert.ToDouble(txtPrice.Text)));
            cmd.Parameters.AddWithValue("@quant", lblAvailabelQuant.Text);
            cmd.Parameters.AddWithValue("@id", txtBookId.Text);

            //printing the result
            int result = cmd.ExecuteNonQuery();
            Response.Write(result <= 0 ? "update failed " : "update sucessfull");
            
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    //add quantity to the book
    protected void btnAddQuant_Click(object sender, EventArgs e)
    {
        try
        {//add quantity of the book
            int add = Convert.ToInt32(txtQuantity.Text);
            if (add < 0) throw new Exception("cannot add nedative number");
            int totalQuant = Convert.ToInt32(lblAvailabelQuant.Text) + add ;
            lblAvailabelQuant.Text = "" + totalQuant;
        }catch(Exception ex)
        {
            Response.Write("Please enter valid number");
        }
    }

    //subtracting quantity of the book
    protected void btnSubtractQuant_Click(object sender, EventArgs e)
    {
        try
        {
            int currentQuant = Convert.ToInt32(lblAvailabelQuant.Text);
            int subQuant = Convert.ToInt32(txtQuantity.Text);
            if (subQuant < 0) throw new Exception(" please add a valid no");
            //validating fot the quantity so it cannot go in negative
            if (subQuant > currentQuant)
            {
                throw new Exception("quantity cannot be negative ");//if quantaty is smaller than quantity to subtract
            }
            else
            {
                int totalQuant = currentQuant - subQuant;
                lblAvailabelQuant.Text = "" + totalQuant;
            }
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        
    }

    //fucntion activated on button click that adds the book to the database
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //clearing the feilds and unabling the input feils and quantity button and feilds to add the data;
            EnableInputFeilds(true);
            QuantityAddSubFeildsVisible(true);
            txtBookId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            lblAvailabelQuant.Text = "0";

            //selecting default drop down that is --select --
            BookIdDropDown.SelectedIndex = 0;

            btnEdit.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }catch(Exception ex)
        {

        }
    }

    //function to add the product
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            BookNameCheck(txtName.Text);
            con = DataConnection.GetDataConnection();
            con.Open();
            //checking for negative pricing
            
            int quant = Convert.ToInt32(lblAvailabelQuant.Text);
            //checking for negative quantity
            if (quant < 0) throw new Exception("quantity cannot be negative");

            //command to insert book into database
            SqlCommand cmd = new SqlCommand("insert into ProductMaster values(@name, @price, @quant)",con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@price", PriceCheck(Convert.ToDouble(txtPrice.Text)));//checking for neative price
            cmd.Parameters.AddWithValue("@quant", quant);

            //executing the command and printing the result
            int result = cmd.ExecuteNonQuery();
            Response.Write(result > 0 ? "Book added sucessfully" : "Failed to add book");
            RefreshBookIdList();//refreasining the book list
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

    //button to delet using the id
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //checking for default value
            if (BookIdDropDown.Text == "--select id  --")
            {
                Response.Write("please select an Book Id");
            }
            else
            {
                //getting the connection
                con = DataConnection.GetDataConnection();
                con.Open();
                //command to delete the book using id
                SqlCommand cmd = new SqlCommand("delete from ProductMaster where ProdID=@id", con);
                cmd.Parameters.AddWithValue("@id", BookIdDropDown.Text);

                // executing the query and printing the resuult
                int result = cmd.ExecuteNonQuery();
                Response.Write(result <= 0 ? "failed delete " : " book deleted sucessfully");
                RefreshBookIdList();
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

    //buton that resents the form
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            //refreshing the page
            con = DataConnection.GetDataConnection();
            con.Open();
            RefreshBookIdList();
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            //checking if connection is null or open
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}