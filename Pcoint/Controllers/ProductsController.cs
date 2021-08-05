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
        public class ProductsController : Controller
        {
            private readonly PcointContext _context;

            public ProductsController(PcointContext context)
            {
                _context = context;
            }

            // GET: Products
            public async Task<IActionResult> Index()
            {
            if (HttpContext.Session.GetString("Id") != null || HttpContext.Session.GetString("LoginUser") != null)
            {
                var value = HttpContext.Session.GetString("Id");
                var name = HttpContext.Session.GetString("LoginUser");
                var Authenticate = _context.Authenticate.Where(x => x.Id == Convert.ToInt32(value)).FirstOrDefault();

                if (name == "Admin@hotmail.com")
                {
                    return View(await _context.Products.ToListAsync());
                    }
                    else
                    {
                    if (_context.Products.ToList().Count == 0)
                    {
                        return RedirectToAction(nameof(NoProduct));
                    }
                    else
                    return RedirectToAction("Index", "Item");
                    }
            }
            else
                return RedirectToAction("UserAuthenticate", "Authenticate");
            }

            // GET: Products/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Products = await _context.Products
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Products == null)
                {
                    return NotFound();
                }

                return View(Products);
            }
        public IActionResult NoProduct()
        {
            return View();
        }
        
        // GET: Products/Create
        public IActionResult Create()
            {
            return View();
            }

            // POST: Products/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,LaptopModel,Brand,Size,Price")] Products Products)
            {
                if (ModelState.IsValid)
                {
                    //Products.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                    _context.Add(Products);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Products);
            }

            // GET: Products/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Products = await _context.Products.FindAsync(id);
                if (Products == null)
                {
                    return NotFound();
                }
                return View(Products);
            }

            // POST: Products/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,LaptopModel,Brand,Size,Price")] Products Products)
            {
                if (id != Products.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Products);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductsExists(Products.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(Products);
            }

            // GET: Products/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Products = await _context.Products
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Products == null)
                {
                    return NotFound();
                }

                return View(Products);
            }

            // POST: Products/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Products = await _context.Products.FindAsync(id);
                _context.Products.Remove(Products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ProductsExists(int id)
            {
                return _context.Products.Any(e => e.Id == id);
            }
        }
    }
