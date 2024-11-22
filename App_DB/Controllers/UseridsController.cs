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
    public class UseridsController : Controller
    {
        private readonly demoDBContext _context;

        public UseridsController(demoDBContext context)
        {
            _context = context;
        }

        // GET: Userids
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Userids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userid = await _context.Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (userid == null)
            {
                return NotFound();
            }

            return View(userid);
        }

        // GET: Userids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,loginid,loginpass,uname,sesid")] Userid userid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userid);
        }

        // GET: Userids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userid = await _context.Users.FindAsync(id);
            if (userid == null)
            {
                return NotFound();
            }
            return View(userid);
        }

        // POST: Userids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,loginid,loginpass,uname,sesid")] Userid userid)
        {
            if (id != userid.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UseridExists(userid.id))
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
            return View(userid);
        }

        // GET: Userids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userid = await _context.Users
                .FirstOrDefaultAsync(m => m.id == id);
            if (userid == null)
            {
                return NotFound();
            }

            return View(userid);
        }

        // POST: Userids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userid = await _context.Users.FindAsync(id);
            if (userid != null)
            {
                _context.Users.Remove(userid);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UseridExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}
