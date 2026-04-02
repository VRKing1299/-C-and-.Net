using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment12Lib;

/// <summary>
/// Code-behind class for the product sorting page.
/// Handles page events and user interactions,
/// such as sorting products by price when the button is clicked.
/// </summary>
public partial class S3SortProductsbyPriceUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // sorting products by price when the button is clicked.
    protected void btnSortProductByPrice_Click(object sender, EventArgs e)
    {
        try
        {
            //inserting products in list
            List<Product> productList = new List<Product>()
            {
                #region
                new Product() {Id=1,Name="Biryani", Price=200 },
                new Product() {Id=2, Name="Cupboard",Price = 34000 },
                new Product() {Id=3, Name="Mirror",Price = 2300 },
                new Product() {Id=4, Name="Monito",Price = 25000 },
                new Product() {Id=5, Name="Tablet",Price = 15000 }
                #endregion
            };

            //sorting products by price
            List<Product> sortedProductList = productList.OrderBy(prd => prd.Price).ToList();

            //displaying the product
            foreach (Product prd in sortedProductList)
            {
                Response.Write("ID :" + prd.Id + ", Name : " + prd.Name + ", Price : " + prd.Price + "<br>");
            }
        }catch(Exception ex) { }
    }
}

