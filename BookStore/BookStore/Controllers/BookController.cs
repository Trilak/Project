using BookStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Book


        public ActionResult Index()
        {


            return View(db.Books.ToList());
        }


        [ValidateAntiForgeryToken]
        public ActionResult MyBook(tblUser objUser)
        {
            var obj = db.Books.Where(a => a.Author.Equals(Session["Username"])).FirstOrDefault();

            if (obj != null)
            {
                
                return View(obj);
            }
            else
            {

                return View(obj);
            }
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);

            return View(databyid);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            try
            {
                Books book = new Books();
                
                if (ModelState.IsValid)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedImages"), fileName);
                        file.SaveAs(path);
                        book.Coverimg = fileName;
                    }

                    var file1 = Request.Files[1];
                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileNames = Path.GetFileName(file1.FileName);
                        var path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileNames);
                        file1.SaveAs(path);
                        book.Content = fileNames;
                    }


                    book.Author = Convert.ToString(Session["Username"]);
                    book.Title = fc["Title"];
                    book.Category = fc["Category"];
                    book.Description = fc["Description"];
                    book.Price = Convert.ToDecimal(fc["Price"]);          

                    db.Books.Add(book);
                    db.SaveChanges();
                }

            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);
            return View(databyid);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Books collection)
        {
            try
            {
                Books bookObj = db.Books.Single(x => x.Book_id == id);

                
                    bookObj.Book_id = collection.Book_id;
                    bookObj.Author = collection.Author;
                    bookObj.Title = collection.Title;
                    bookObj.Category = collection.Category;
                    bookObj.Description = collection.Description;
                    bookObj.Price = collection.Price;
                    bookObj.Content = collection.Content;
                    bookObj.Coverimg = collection.Coverimg;
          
                    db.SaveChanges();
 
                    return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var databyid = db.Books.Single(x => x.Book_id == id);
            return View(databyid);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var bookdatabyid = db.Books.Single(x => x.Book_id == id);
                db.Books.Remove(bookdatabyid);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ViewResult ViewBooks()
        {
            IEnumerable<Books> model = null;
            model = (from user in db.tblUser
                     join b in db.Books on user.Username equals b.Author
                     select new Books
                     {
                        
                         

                     });

            return View(model);
        }
    }
}
