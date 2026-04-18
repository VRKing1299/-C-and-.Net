using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ExamWebApi.Models;

namespace ExamWebApi.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "SampleHeader")]
    public class CartController : ApiController
    {
        //retrive all data
        [HttpGet]
        [Route("GetAll")]
        public List<Cart> GetCarts()
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<Cart> carts = db.Carts.ToList();
            return carts;
        }
        //retrive data from cart based on CartID
        [HttpGet]
        [Route("GetById/{ID}")]
        public Cart GetCartById(int ID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            Cart c = db.Carts.Where(temp => temp.CartID == ID).FirstOrDefault();
            return c;
        }
        //reteive data from cart based on UserID
        [HttpGet]
        [Route("api/Cart/GetCartByUserID/{UserID}")]
        public List<Cart> GetCartByUserID(int UserID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<Cart> carts = db.Carts.Where(c => c.UserID == UserID).ToList();
            return carts;
        }
        //method to retrive data from databse by using product id 
        [HttpGet]
        [Route("api/Cart/Search/{productId}")]
        public List<Cart> GetProdByID(int productId)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<Cart> requiredProduct = db.Carts.Where(prod => prod.ProdID == productId).ToList();
            return requiredProduct;
        }
        //method to insert record in database 
        [HttpPost]
        [Route("api/Cart/Add")]
        public void PostCartDetails(Cart c)
        {
            try
            {
           
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                db.Carts.Add(c);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log the exception message here
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        [HttpPut]
        [Route("api/Cart/Update")]
        public void PutUpdateProd(Cart c)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                Cart existing = db.Carts.Where(item => item.CartID == c.CartID).FirstOrDefault();
                existing.CartQty = c.CartQty;
                //existing.ProdPrice = c.ProdQty * existing.ProdPrice;
                db.SaveChanges();
            }
            catch (Exception) { }
        }
        [HttpDelete]
        [Route("api/Cart/Remove")]
        public void DeleteCart(int CartID)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                Cart product = db.Carts.Where(item => item.CartID == CartID).FirstOrDefault();
                db.Carts.Remove(product);
                db.SaveChanges();
            }
            catch (Exception) { }
        }

    }
}
