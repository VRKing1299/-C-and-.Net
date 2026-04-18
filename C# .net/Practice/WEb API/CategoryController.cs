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
    public class CategoryController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "SampleHeader")]

        //it is use to retrive data from database ,all the data will store in list cat
        public List<Category> GetCategory()
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                List<Category> cat = db.Categories.ToList();
                return cat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //it is used to retrive data from database by using category id,it is use to fetch 1st record

        public Category GetCategoryByID(int ID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            //retriving data from cat list by using firstOrDefault ,which return 1st element 
            Category c = db.Categories.Where(temp => temp.categoryId == ID).FirstOrDefault();
            return c;
        }
        public void PostCategoryData(Category cat)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                db.Categories.Add(cat);

                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void PutCategoryData(Category catData)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            var exitingCat = db.Categories.Where(temp => temp.categoryId == catData.categoryId).FirstOrDefault();
            exitingCat.categoryName = catData.categoryName;
            db.SaveChanges();
        }
        public void DeleteCat(long ID)
        {
            ExamWebApiDbEntities db = new ExamWebApiDbEntities();
            var exitingCat = db.Categories.Where(temp => temp.categoryId == ID).FirstOrDefault();
            db.Categories.Remove(exitingCat);
            db.SaveChanges();
        }
    }
}
