using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App_DB.Data;
using App_DB.Models;

namespace App_DB.Controllers
{
    public class CartdetailsController : Controller
    {
        private readonly demoDBContext _context;

        public CartdetailsController(demoDBContext context)
        {
            _context = context;
        }

        // GET: Cartdetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cartsdetails.ToListAsync());
        }

        // GET: Cartdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartdetail = await _context.Cartsdetails
                .FirstOrDefaultAsync(m => m.Cartid == id);
            if (cartdetail == null)
            {
                return NotFound();
            }

            return View(cartdetail);
        }

        // GET: Cartdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cartdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cartid,Proid,Quantity")] Cartdetail cartdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartdetail);
        }

        // GET: Cartdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartdetail = await _context.Cartsdetails.FindAsync(id);
            if (cartdetail == null)
            {
                return NotFound();
            }
            return View(cartdetail);
        }

        // POST: Cartdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cartid,Proid,Quantity")] Cartdetail cartdetail)
        {
            if (id != cartdetail.Cartid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartdetailExists(cartdetail.Cartid))
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
            return View(cartdetail);
        }

        // GET: Cartdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartdetail = await _context.Cartsdetails
                .FirstOrDefaultAsync(m => m.Cartid == id);
            if (cartdetail == null)
            {
                return NotFound();
            }

            return View(cartdetail);
        }

        // POST: Cartdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartdetail = await _context.Cartsdetails.FindAsync(id);
            if (cartdetail != null)
            {
                _context.Cartsdetails.Remove(cartdetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartdetailExists(int id)
        {
            return _context.Cartsdetails.Any(e => e.Cartid == id);
        }
    }
}
