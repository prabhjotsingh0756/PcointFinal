using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pcoint.Data;
using Pcoint.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Pcoint.Controllers
{
    public class ProductController : Controller
    {
        private readonly PcointContext _context;

        public ProductController(PcointContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
          return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> AddItem(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                YourProducts buyBook = new YourProducts();
                var book = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                buyBook.LaptopModel = book.LaptopModel;
                buyBook.Brand = book.Brand;
                buyBook.Size = book.Size;
                buyBook.Price = book.Price;
                buyBook.UserId = Convert.ToInt32(value);
                _context.Add(buyBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "YourProducts");
            }
            else
                return RedirectToAction("UserAuthenticate", "Authenticate");
        }

    }
}
