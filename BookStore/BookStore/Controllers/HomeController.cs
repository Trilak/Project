using BookStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BookStoreEntities db = new BookStoreEntities();

        public ActionResult Index(FormCollection fc)
        {

            return View(db.Books.OrderByDescending(books => books.Book_id).Take(10).ToList());
        }

        public ActionResult Shelf()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);

            return View(databyid);
        }

        public ActionResult Buy(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);

            return View(databyid);
        }

        // POST: a/Edit/5
        [HttpPost]
        public ActionResult Buy(FormCollection fc)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    if (fc["Card_no"] != null)
                    {
                        tblOrder orderObj = new tblOrder();

                        orderObj.User_id = Convert.ToInt32(Session["User_ID"]);
                        orderObj.Book_id = Convert.ToInt32(fc["Book_id"]);
                        orderObj.Price = Convert.ToDecimal(fc["Price"]);
                        orderObj.Order_date = DateTime.Now;
                        orderObj.Card_no = fc["Card_no"];
                        db.tblOrder.Add(orderObj);
                        db.SaveChanges();

                    }
                    else
                    {
                        return View();
                    }
                    
                }

            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");
        }



     
        public FileStreamResult GetPDF(string ParamName)
        {

   
            string a = Convert.ToString(ParamName);
    
            var filePath = Path.Combine(Server.MapPath("~/UploadedFiles/"), a);
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            return File(fs, "application/pdf");





        }

    }
}
