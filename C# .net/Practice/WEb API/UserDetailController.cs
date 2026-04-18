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

    public class UserDetailController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "SampleHeader")]
        ///this method is used to get all the user details///
        [HttpGet]
        [Route("api/UserDetail/GetAllUser")]
        public List<UserDetail> GetUserDetails()
        {
            //using exception handling mechanism
            try {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                List<UserDetail> userdetails = db.UserDetails.ToList();
                return userdetails;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //this method is used to get a user by it's id
        public UserDetail GetUserByID(int ID)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                UserDetail ud = db.UserDetails.Where(temp => temp.UserID == ID).FirstOrDefault();
                return ud;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //this method is used to get the user object using it's username
        [HttpGet]
        [Route("api/UserDetail/GetUserByUserName")]
        public UserDetail GetUserByUserName(string Username)
        {
            try {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                UserDetail ud = db.UserDetails.Where(temp => temp.UserName == Username).FirstOrDefault();
                return ud;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //this method is used to insert user details in the database
        [HttpPost]
        [Route("api/UserDetail")]
        public IHttpActionResult PostUserData()
        {
            try
            {
                var form = HttpContext.Current.Request.Form;
                var userDetail = new UserDetail
                {
                    UserName = form["UserName"],
                    UserEmail = form["UserEmail"],
                    UserPassword = form["UserPassword"],
                    UserConfirmPassword = form["UserConfirmPassword"],
                    TypeId = int.Parse(form["TypeID"])
                };

                using (var db = new ExamWebApiDbEntities())
                {
                    db.UserDetails.Add(userDetail);
                    db.SaveChanges();
                    return Ok("User registered successfully.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return InternalServerError(ex);
            }
        }


        //This method will Update the data in table
        public void PutUserData(UserDetail user)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                var exitingUser = db.UserDetails.Where(temp => temp.UserID == user.UserID).FirstOrDefault();
                exitingUser.UserName = user.UserName;
                exitingUser.UserEmail = user.UserEmail;
                exitingUser.UserPassword = user.UserPassword;
                exitingUser.UserType = user.UserType;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //this method will delete the data from the table
        public void DeleteUserData(long ID)
        {
            try
            {
                ExamWebApiDbEntities db = new ExamWebApiDbEntities();
                var exitingUser = db.UserDetails.Where(temp => temp.UserID == ID).FirstOrDefault();
                db.UserDetails.Remove(exitingUser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
