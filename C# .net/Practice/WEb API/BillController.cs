using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExamWebApi.Models;
using System.Web.Http.Cors;

namespace ExamWebApi.ApiControllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "SampleHeader")]
    public class BillController : ApiController
    {
        
        //this method is used to get all the bills
        public List<Bill> GetBills()
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                List<Bill> bills = db.Bills.ToList();
                return bills;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //this method is used to insert a new bill in database
        public void PostBill(Bill b)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                db.Bills.Add(b);
                db.SaveChanges();
            }
            catch (Exception )
            {
               
            }
        }
        //this method is used to get a list of bill for a particular user
        [HttpGet]
        [Route("api/Bill/GetByUser/{userId}")]
        public IHttpActionResult GetBillsByUserId(int userId)
        {
            try
            {
                using (ExamWebApiDbEntities db = new ExamWebApiDbEntities())
                {
                    var bills = db.Bills.Where(temp => temp.UserID == userId).ToList();
                    return Ok(bills);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return InternalServerError(ex);
            }
        }



    }
}
