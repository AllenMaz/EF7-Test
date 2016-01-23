using EntityFramework7.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework7.Controllers
{
    public class BlogsController : Controller
    {
        private EFDBContext _context;

        public BlogsController(EFDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

    }
}
