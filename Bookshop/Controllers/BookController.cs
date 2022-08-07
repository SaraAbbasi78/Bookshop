using Bookshop.Data;
using Bookshop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var model = _db.Books;
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book model)
        {
            _db.Books.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _db.Entry(model).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
