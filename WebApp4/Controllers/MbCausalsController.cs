using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp4.Models;

namespace WebApp4.Controllers
{
    public class MbCausalsController : Controller
    {
        private readonly TestContext _context;

        public MbCausalsController(TestContext context)
        {
            _context = context;
        }

        // GET: MbCausals
        public async Task<IActionResult> Index()
        {
            var testContext = _context.MbCausal.Include(m => m.MbcsMbmg).Include(m => m.MbcsMgau);
            return View(await testContext.ToListAsync());
        }

        // GET: MbCausals/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbCausal = await _context.MbCausal
                .Include(m => m.MbcsMbmg)
                .Include(m => m.MbcsMgau)
                .FirstOrDefaultAsync(m => m.MbcsId == id);
            if (mbCausal == null)
            {
                return NotFound();
            }

            return View(mbCausal);
        }

        // GET: MbCausals/Create
        public IActionResult Create()
        {
            ViewData["MbcsMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            ViewData["MbcsMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl");
            return View();
        }

        // POST: MbCausals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MbcsId,MbcsMbmgId,MbcsCaus,MbcsDescr,MbcsMgauId")] MbCausal mbCausal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbCausal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MbcsMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mbCausal.MbcsMbmgId);
            ViewData["MbcsMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mbCausal.MbcsMgauId);
            return View(mbCausal);
        }

        // GET: MbCausals/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbCausal = await _context.MbCausal.FirstOrDefaultAsync(m => m.MbcsId == id);
            if (mbCausal == null)
            {
                return NotFound();
            }
            ViewData["MbcsMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mbCausal.MbcsMbmgId);
            ViewData["MbcsMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mbCausal.MbcsMgauId);
            return View(mbCausal);
        }

        // POST: MbCausals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("MbcsId,MbcsMbmgId,MbcsCaus,MbcsDescr,MbcsMgauId")] MbCausal mbCausal)
        {
            if (id != mbCausal.MbcsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mbCausal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MbCausalExists(mbCausal.MbcsId))
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
            ViewData["MbcsMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mbCausal.MbcsMbmgId);
            ViewData["MbcsMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mbCausal.MbcsMgauId);
            return View(mbCausal);
        }

        // GET: MbCausals/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbCausal = await _context.MbCausal
                .Include(m => m.MbcsMbmg)
                .Include(m => m.MbcsMgau)
                .FirstOrDefaultAsync(m => m.MbcsId == id);
            if (mbCausal == null)
            {
                return NotFound();
            }

            return View(mbCausal);
        }

        // POST: MbCausals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var mbCausal = await _context.MbCausal.FirstOrDefaultAsync(m => m.MbcsId == id);
            _context.MbCausal.Remove(mbCausal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MbCausalExists(short id)
        {
            return _context.MbCausal.Any(e => e.MbcsId == id);
        }
    }
}
