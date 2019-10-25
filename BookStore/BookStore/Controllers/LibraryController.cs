using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class LibraryController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Library
        public ActionResult Index()
        {
            
            return View();
        }


        public ViewResult ViewBook()
        {

            IEnumerable<LibraryViewModel> model = null;


            string name = Convert.ToString(Session["Username"]);

            model = (from order in db.tblOrder
                     join b in db.Books on order.Book_id equals b.Book_id
                     join user in db.tblUser on order.User_id equals user.User_id

                     where user.Username.Equals(name)

                     select new LibraryViewModel
                     {
                         Id = b.Book_id,
                         Author = b.Author,
                         Title = b.Title,
                         Category = b.Category,
                         Description = b.Description,
                         Price = b.Price,
                         Coverimg = b.Coverimg,
                         Content = b.Content
                     });

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);

            return View(databyid);
        }

    }
}