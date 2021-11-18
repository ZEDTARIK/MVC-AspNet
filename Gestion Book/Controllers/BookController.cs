using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion_Book.Models;

namespace Gestion_Book.Controllers
{
    public class BookController : Controller
    {

        private static List<Book> books;

        // GET: Book
        public ActionResult Index()
        {
            if(books == null)
            {
                books = new List<Book>();
                books.Add(new Book { 
                    Id=1,
                    Author= "Zouhair ETTARAK",
                    Title ="Learn Asp"
                });

                books.Add(new Book
                {
                    Id = 2,
                    Author = "Giovanni Colleci",
                    Title = "Learn IDM Italiano"
                });

            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = books.Single(b => b.Id == id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                // TODO: Add insert logic here
                books.Add(book);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = books.Single(b => b.Id == id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                Book old_book = books.Single(b => b.Id == id);
                old_book.Author = book.Author;
                old_book.Title = book.Title;

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
            Book book = books.Single(b => b.Id == id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                Book bookDeleted = books.Single(b => b.Id == id);
                books.Remove(bookDeleted);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
