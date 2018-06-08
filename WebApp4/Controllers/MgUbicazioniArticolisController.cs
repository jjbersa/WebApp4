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
    public class MgUbicazioniArticolisController : Controller
    {
        private readonly TestContext _context;

        public MgUbicazioniArticolisController(TestContext context)
        {
            _context = context;
        }

        // GET: MgUbicazioniArticolis
        public async Task<IActionResult> Index()
        {
            var testContext = _context.MgUbicazioniArticoli.Include(m => m.MguaMbmg).Include(m => m.MguaMgaa).Include(m => m.MguaMgau);
            return View(await testContext.ToListAsync());
        }

        // GET: MgUbicazioniArticolis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgUbicazioniArticoli = await _context.MgUbicazioniArticoli
                .Include(m => m.MguaMbmg)
                .Include(m => m.MguaMgaa)
                .Include(m => m.MguaMgau)
                .FirstOrDefaultAsync(m => m.MguaId == id);
            if (mgUbicazioniArticoli == null)
            {
                return NotFound();
            }

            return View(mgUbicazioniArticoli);
        }

        // GET: MgUbicazioniArticolis/Create
        public IActionResult Create()
        {
            ViewData["MguaMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            ViewData["MguaMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr");
            ViewData["MguaMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl");
            return View();
        }

        // POST: MgUbicazioniArticolis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MguaId,MguaMgaaId,MguaMbmgId,MguaMgauId")] MgUbicazioniArticoli mgUbicazioniArticoli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mgUbicazioniArticoli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MguaMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgUbicazioniArticoli.MguaMbmgId);
            ViewData["MguaMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgUbicazioniArticoli.MguaMgaaId);
            ViewData["MguaMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgUbicazioniArticoli.MguaMgauId);
            return View(mgUbicazioniArticoli);
        }

        // GET: MgUbicazioniArticolis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgUbicazioniArticoli = await _context.MgUbicazioniArticoli.FirstOrDefaultAsync(m => m.MguaId == id);
            if (mgUbicazioniArticoli == null)
            {
                return NotFound();
            }
            ViewData["MguaMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgUbicazioniArticoli.MguaMbmgId);
            ViewData["MguaMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgUbicazioniArticoli.MguaMgaaId);
            ViewData["MguaMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgUbicazioniArticoli.MguaMgauId);
            return View(mgUbicazioniArticoli);
        }

        // POST: MgUbicazioniArticolis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MguaId,MguaMgaaId,MguaMbmgId,MguaMgauId")] MgUbicazioniArticoli mgUbicazioniArticoli)
        {
            if (id != mgUbicazioniArticoli.MguaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mgUbicazioniArticoli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MgUbicazioniArticoliExists(mgUbicazioniArticoli.MguaId))
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
            ViewData["MguaMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgUbicazioniArticoli.MguaMbmgId);
            ViewData["MguaMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgUbicazioniArticoli.MguaMgaaId);
            ViewData["MguaMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgUbicazioniArticoli.MguaMgauId);
            return View(mgUbicazioniArticoli);
        }

        // GET: MgUbicazioniArticolis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgUbicazioniArticoli = await _context.MgUbicazioniArticoli
                .Include(m => m.MguaMbmg)
                .Include(m => m.MguaMgaa)
                .Include(m => m.MguaMgau)
                .FirstOrDefaultAsync(m => m.MguaId == id);
            if (mgUbicazioniArticoli == null)
            {
                return NotFound();
            }

            return View(mgUbicazioniArticoli);
        }

        // POST: MgUbicazioniArticolis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mgUbicazioniArticoli = await _context.MgUbicazioniArticoli.FirstOrDefaultAsync(m => m.MguaId == id);
            _context.MgUbicazioniArticoli.Remove(mgUbicazioniArticoli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MgUbicazioniArticoliExists(int id)
        {
            return _context.MgUbicazioniArticoli.Any(e => e.MguaId == id);
        }
    }
}
