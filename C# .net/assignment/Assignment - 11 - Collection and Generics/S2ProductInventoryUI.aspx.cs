using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S2ProductInventoryLib;


/// <summary>
/// this class had btnSearchProduct_Click method with is activated on user input i.e button click
/// </summary>
public partial class S2ProductInventoryUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this button demonstraits use of key and searing by key
    protected void btnSearchProduct_Click(object sender, EventArgs e)
    {
        try
        {
            #region//creating product object
            Product p1 = new Product(101, "fanta");
            Product p2 = new Product(102, "milinda");
            Product p3 = new Product(103, "sanfransisco");
            Product p4 = new Product(104, "sarso ka Oil");
            Product p5 = new Product(105, "shikanji");
            #endregion

            //creating dictionary with type key as int and value as Product
            Dictionary<int, Product> productList = new Dictionary<int, Product>();

            #region//adding entries to the product
            productList.Add(p1.ProductID, p1);
            productList.Add(p2.ProductID, p2);
            productList.Add(p3.ProductID, p3);
            productList.Add(p4.ProductID, p4);
            productList.Add(p5.ProductID, p5);
            #endregion

            //key to search
            int keySearch = 104;

            //checking if key is present or not
            bool productKey = productList.ContainsKey(keySearch);

            #region//if present printing the result
            if (productKey)
            {
                Product p = productList[keySearch];
                Response.Write("product found : id" + p.ProductID + ", Name : " + p.ProductName);
            }
            else
            {
                Response.Write("Key is not present ");
            }
            #endregion
        }catch(Exception ex) { }
    }
}