using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S10GenericReportGeneratorLib;

public partial class S10GenericReportGeneratorUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //generetaes the  report for employees
    protected void btnEmployeeReport_Click(object sender, EventArgs e)
    {
        try
        {
            //list of employees
            List<Employee> employees = new List<Employee>()
            {
                #region
                new Employee(1,"aa"),
                new Employee(2,"bb"),
                new Employee(3,"cc")
                #endregion
            };
            //generating the report
            GenerateReport(employees);
        }catch(Exception ex) { }
    }

    //generetaes the report for Products
    protected void btnProductReport_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //list of products
            List<Product> products = new List<Product>()
            {
                new Product(101,"Laptop"),
                new Product(102,"Mouse"),
                new Product(103,"Keyboard")
            };
            //generating the report
            GenerateReport(products);
            #endregion
        }
        catch (Exception ex) { }
    }

    //generetaes the report for Order
    protected void btnOrderReport_Click(object sender, EventArgs e)
    {
        try
        {
            //list of orders
            List<Order> orders = new List<Order>()
            {
                #region
                new Order(11,"bottle"),
                new Order(22,"pineapple"),
                new Order(33,"carrot")
                #endregion
            };
            //generating the report
            GenerateReport(orders);
        }catch(Exception ex) { }
    }

    //generic method for generating the report
    public void GenerateReport<T>(List<T> items)
    {
        foreach (T obj in items)
        {
            Response.Write(obj+"<br>");
        }
    }
}