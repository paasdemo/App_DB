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
    public class ProcatesController : Controller
    {
        private readonly demoDBContext _context;

        public ProcatesController(demoDBContext context)
        {
            _context = context;
        }

        // GET: Procates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Processes.ToListAsync());
        }

        // GET: Procates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procate = await _context.Processes
                .FirstOrDefaultAsync(m => m.Cateid == id);
            if (procate == null)
            {
                return NotFound();
            }

            return View(procate);
        }

        // GET: Procates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cateid,Catename")] Procate procate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procate);
        }

        // GET: Procates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procate = await _context.Processes.FindAsync(id);
            if (procate == null)
            {
                return NotFound();
            }
            return View(procate);
        }

        // POST: Procates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cateid,Catename")] Procate procate)
        {
            if (id != procate.Cateid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcateExists(procate.Cateid))
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
            return View(procate);
        }

        // GET: Procates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procate = await _context.Processes
                .FirstOrDefaultAsync(m => m.Cateid == id);
            if (procate == null)
            {
                return NotFound();
            }

            return View(procate);
        }

        // POST: Procates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procate = await _context.Processes.FindAsync(id);
            if (procate != null)
            {
                _context.Processes.Remove(procate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcateExists(int id)
        {
            return _context.Processes.Any(e => e.Cateid == id);
        }
    }
}
