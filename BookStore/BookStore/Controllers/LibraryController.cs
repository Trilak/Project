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
            IEnumerable<BooksViewModel> model = null;

            model = (from user in db.tblUser
                     join b in db.Books on user.Username equals b.Author
                     where user.Username.Equals(Session["Username"])

                     select new BooksViewModel
                     {
                         Author = user.Username,
                         Title = b.Title,
                         Category = b.Category,
                         Description = b.Description,
                         Price = b.Price,
                         Coverimg = b.Coverimg,
                         Content = b.Content
                     });

            return View(model);
        }

    }
}