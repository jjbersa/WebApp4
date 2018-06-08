using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp4.Controllers
{
    public class PkAnagsController : Controller
    {
        private readonly TestContext _context;

        public PkAnagsController(TestContext context)
        {
            _context = context;
        }

        // GET: PkAnags
        public async Task<IActionResult> Index()
        {
            return View(await _context.PkAnag.Include(s => s.PkArticoli).ThenInclude(p => p.PkarMgaa).ToListAsync());
        }

        // GET: PkAnags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkAnag = await _context.PkAnag
                .Include(s => s.PkArticoli).ThenInclude(p => p.PkarMgaa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PkanId == id);
            if (pkAnag == null)
            {
                return NotFound();
            }

            return View(pkAnag);
        }

        // GET: PkAnags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PkAnags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkanId,PkanNum,PkanData,PkanDesc,PkanNote,PkanScaric,PkanYear")] PkAnag pkAnag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pkAnag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pkAnag);
        }

        // GET: PkAnags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkAnag = await _context.PkAnag.FirstOrDefaultAsync(m => m.PkanId == id);
            if (pkAnag == null)
            {
                return NotFound();
            }
            return View(pkAnag);
        }

        // POST: PkAnags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkanId,PkanNum,PkanData,PkanDesc,PkanNote,PkanScaric,PkanYear")] PkAnag pkAnag)
        {
            if (id != pkAnag.PkanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pkAnag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PkAnagExists(pkAnag.PkanId))
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
            return View(pkAnag);
        }

        // GET: PkAnags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkAnag = await _context.PkAnag
                .FirstOrDefaultAsync(m => m.PkanId == id);
            if (pkAnag == null)
            {
                return NotFound();
            }

            return View(pkAnag);
        }

        // POST: PkAnags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pkAnag = await _context.PkAnag.FirstOrDefaultAsync(m => m.PkanId == id);
            _context.PkAnag.Remove(pkAnag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PkAnagExists(int id)
        {
            return _context.PkAnag.Any(e => e.PkanId == id);
        }

        // GET: PkAnags/Accept/5
        public async Task<IActionResult> Accept(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkAnag = await _context.PkAnag
                .Include(s => s.PkArticoli).ThenInclude(p => p.PkarMgaa)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PkanId == id);
            if (pkAnag == null)
            {
                return NotFound();
            }

            return View(pkAnag);
        }

        // POST: PkAnags/Accept/5
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptConfirmed(int id)
        {            

            var pkAnag = await _context.PkAnag
                .Include(s => s.PkArticoli).ThenInclude(p => p.PkarMgaa)
                .AsNoTracking().FirstOrDefaultAsync(m => m.PkanId == id);
            pkAnag.PkanScaric = true;
            foreach(var item in pkAnag.PkArticoli)
            {
                item.PkarTransferred = true;
                item.PkarQtaSca = item.PkarQtaPick;
            }
            _context.Update(pkAnag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
