using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        // GET /Books/Random
        public IActionResult Random ()
        {
            var firstBook = new Book() { Name = "English dictionary" };

            //ViewData["Book"] = firstBook;
            ViewBag.Book = firstBook;

            return View();
                
        }

        public IActionResult Edit (int id)
        {
            return Content("id=" + id);
        }

        public IActionResult Index( int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrEmpty(sortBy))
            {
                sortBy = "Name";
            }

            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        } 

        [Route("books/released/{year:regex(^\\d{{4}}$)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate( int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
