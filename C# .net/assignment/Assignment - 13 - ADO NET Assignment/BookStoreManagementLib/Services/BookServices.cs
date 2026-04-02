using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BookStoreManagementLib.Models;

namespace BookStoreManagementLib.Services
{
    public class BookServices
    {
        SqlConnection con;

        public BookServices() { }
        public BookServices(SqlConnection con)
        {
            this.con = con;
        }

        // method to get all the data of books
        public SqlDataReader GetAllBooksData()
        {
            SqlCommand cmd = new SqlCommand("select * from ProductMaster",con);
            return cmd.ExecuteReader();
        }

        public int UpdateBook(Book book)
        {
            SqlCommand cmd = new SqlCommand("update ProductMaster set ProdName=@name, ProdPrice = @price, ProdQuantity = @quantity where ProdID =@id ",con);
            cmd.Parameters.AddWithValue("@name", book.BookName);
            cmd.Parameters.AddWithValue("@price", book.BookPrice);
            cmd.Parameters.AddWithValue("@quantity", book.BookQuantity);
            cmd.Parameters.AddWithValue("@id", book.BookId);
            return cmd.ExecuteNonQuery();
        }

        public Book GetBookById(int id)
        {
            SqlCommand cmd = new SqlCommand("select * from ProductMaster where ProdID = @id",con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader rdr = cmd.ExecuteReader();
            Book book =null;
            if (rdr.Read())
            {
                book = new Book(Convert.ToInt32(rdr["ProdID"]))
                {
                    BookName = rdr["ProdName"].ToString(),
                    BookPrice=Convert.ToDouble(rdr["ProdPrice"]),
                    BookQuantity = Convert.ToInt32(rdr["ProdQuantity"])
                };
            }
            return book;

        }
    }
}
