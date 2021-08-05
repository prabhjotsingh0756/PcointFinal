using Pcoint.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcoint.Controllers
{
    public class YourProductsController : Controller
    {
        private readonly PcointContext _context;

        public YourProductsController(PcointContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                return View(await _context.YourProducts.Where(x => x.UserId == Convert.ToInt32(value)).ToListAsync());
            }
            else
                return RedirectToAction("UserAuthenticate", "Authenticate");
        }
    }
}
