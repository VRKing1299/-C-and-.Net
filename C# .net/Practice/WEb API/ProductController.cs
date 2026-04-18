using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Http.Cors;
using ExamWebApi.Models;

namespace ExamWebApi.ApiControllers
{
    public class ProductController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "SampleHeader")]
        //it is use to retrive data from database ,all the data will store in list prod
        public List<ProductTable> GetProduct()
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                List<ProductTable> prod = db.ProductTables.ToList();
                return prod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        //it is used to retrive data from database by using category id,it is use to fetch 1st record
        //this method is used to get a product from database by it's id
        [HttpGet]
        [Route("api/Product/ProductID/{ProdID}")]
        public ProductTable GetProductByID(int ProdID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            // Retrieving data from product table using FirstOrDefault, which returns the first element
            ProductTable p = db.ProductTables.Where(temp => temp.ProdID == ProdID).FirstOrDefault();
            return p;
        }


        //this method is used to get a product by it's type
        [HttpGet]
        [Route("api/Product/ProductCategory")]
        public List<ProductTable> GetProductByType(int categoryId)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<ProductTable> p = db.ProductTables.ToList();
            List<ProductTable> type = new List<ProductTable>();
            foreach (ProductTable b in p)
            {
                if (b.categoryId == categoryId)
                {
                    type.Add(b);
                }
            }
            return type;
        }

        //this method is used to get a product by it's name
        public ProductTable GetProductByName(string ProdName)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            ProductTable p = db.ProductTables.Where(temp => temp.ProdName == ProdName).FirstOrDefault();
            return p;
        }
        //this method is used to insert a new product in database
        public string PostProduct(ProductTable p)
        {
            try {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                db.ProductTables.Add(p);
                db.SaveChanges();
                return "Added";
            }
            catch(Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            return null;
        }

        //this method is used to update the qty 
        public void PutProductQty(int id, int qty)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            ProductTable existing = db.ProductTables.Where((temp) => temp.ProdID == id).FirstOrDefault();
            existing.ProdQty -= qty;

            db.SaveChanges();
        }

        
        public string PutProductData(int id, ProductTable product)
        {
            try
            {
                using (ExamWebApiDbEntities db = new ExamWebApiDbEntities())
                {
                    var existingProduct = db.ProductTables.FirstOrDefault(p => p.ProdID == id);
                    if (existingProduct != null)
                    {
                        existingProduct.ProdName = product.ProdName;
                        existingProduct.ProdImg = product.ProdImg;
                        existingProduct.ProdDsc = product.ProdDsc;
                        existingProduct.ProdQty = product.ProdQty;
                        existingProduct.ProdPrice = product.ProdPrice;
                        existingProduct.categoryId = product.categoryId;

                        db.SaveChanges();
                        return "Updated";
                    }
                    else
                    {
                        return "Product Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception details here
                return $"Error: {ex.Message}";
            }
        }



        public string DeleteProductDetails(long id)
        {
            try
            {
                using (ExamWebApiDbEntities db = new ExamWebApiDbEntities())
                {
                    var existingProduct = db.ProductTables.FirstOrDefault(p => p.ProdID == id);
                    if (existingProduct != null)
                    {
                        db.ProductTables.Remove(existingProduct);
                        db.SaveChanges();
                        return "Deleted";
                    }
                    else
                    {
                        return "Product Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                // Optionally log the exception details here
                return $"Error: {ex.Message}";
            }
        }

    }
}
