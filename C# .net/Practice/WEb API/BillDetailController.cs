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

    public class BillDetailController : ApiController
    {
        //this method is used to get all the bill details
        public List<BillDetail> GetBillDetail()
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<BillDetail> billDetail = db.BillDetails.ToList();
            return billDetail;
        }
        //this method is used to get the list of billdetails based on a billid
        public List<BillDetail> GetBillDetailByBillID(int BillID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            List<BillDetail> bk = db.BillDetails.ToList();
            List<BillDetail> bill = new List<BillDetail>();
            foreach (BillDetail b in bk)
            {
                if (b.BillID == BillID)
                {
                    bill.Add(b);
                }
            }
            return bill;
        }
        //this method is used to enter bill details in database
        [HttpPost]
        [Route("api/BillDetail/Add")]
        public void PostBill(BillDetail b)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                db.BillDetails.Add(b);
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

    }
}
