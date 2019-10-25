using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tblUser regis)
        {
            try
            {

                regis.User_type = "User";

                db.tblUser.Add(regis);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tblUser objUser)
        {
            if (ModelState.IsValid)
            {
                using (BookStoreEntities db = new BookStoreEntities())
                {
                    var obj = db.tblUser.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["User_id"] = obj.User_id;
                        Session["Username"] = obj.Username;
                        Session["User_type"] = obj.User_type;

                        if (obj.Username != null && obj.User_type != "Admin")
                        {
                            Session["Username"] = obj.Username;
                            Session["User_id"] = obj.User_id;
                            return RedirectToAction("Index", "Home", new { area = "" });
                        }
                        else if (obj.User_type == "Admin")
                        {
                            Session["Username"] = obj.Username;
                            Session["User_id"] = obj.User_id;

                            return RedirectToAction("Admin", "Admin", new { area = "" });
                        }
                        else if (obj.Username == null)
                        {
                            Session["Username"] = obj.Username;
                            Session["User_ID"] = obj.User_id;
                            return RedirectToAction("Login", "Account", new { area = "" });
                        }
                        else
                        {

                        }
                    }
                }
            }
            return View(objUser);
        }



    }
}