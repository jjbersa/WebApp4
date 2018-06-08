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
    public class PkArticolisController : Controller
    {
        private readonly TestContext _context;

        public PkArticolisController(TestContext context)
        {
            _context = context;
        }

        // GET: PkArticolis
        public async Task<IActionResult> Index()
        {
            var testContext = _context.PkArticoli
                .Include(p => p.PkarMbcs)
                .Include(p => p.PkarMbmg)
                .Include(p => p.PkarMgaa)
                .Include(p => p.PkarMgau)
                .Include(p => p.PkarPkan);
            return View(await testContext.ToListAsync());
        }

        // GET: PkArticolis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkArticoli = await _context.PkArticoli
                .Include(p => p.PkarMbcs)
                .Include(p => p.PkarMbmg)
                .Include(p => p.PkarMgaa)
                .Include(p => p.PkarMgau)
                .Include(p => p.PkarPkan)
                .SingleOrDefaultAsync(m => m.PkarId == id);
            if (pkArticoli == null)
            {
                return NotFound();
            }

            return View(pkArticoli);
        }

        // GET: PkArticolis/Create
        public IActionResult Create()
        {
            ViewData["PkarMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus");
            ViewData["PkarMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            ViewData["PkarMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr");
            ViewData["PkarMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl");
            ViewData["PkarPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc");
            return View();
        }

        // POST: PkArticolis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkarId,PkarPkanId,PkarMgaaId,PkarQtaPick,PkarQtaSca,PkarMbmgId,PkarMbcsId,PkarMgauId,PkarMgrgId,PkarMgmvProg,PkarCodice,PkarNote,PkarTransferred")] PkArticoli pkArticoli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pkArticoli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PkarMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", pkArticoli.PkarMbcsId);
            ViewData["PkarMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", pkArticoli.PkarMbmgId);
            ViewData["PkarMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", pkArticoli.PkarMgaaId);
            ViewData["PkarMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", pkArticoli.PkarMgauId);
            ViewData["PkarPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", pkArticoli.PkarPkanId);
            return View(pkArticoli);
        }

        // GET: PkArticolis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkArticoli = await _context.PkArticoli
                .Include(p => p.PkarMbcs)
                .Include(p => p.PkarMbmg)
                .Include(p => p.PkarMgaa)
                .Include(p => p.PkarMgau)
                .Include(p => p.PkarPkan)
                .SingleOrDefaultAsync(m => m.PkarId == id);
            if (pkArticoli == null)
            {
                return NotFound();
            }
            ViewData["PkarMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", pkArticoli.PkarMbcsId);
            ViewData["PkarMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", pkArticoli.PkarMbmgId);
            ViewData["PkarMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", pkArticoli.PkarMgaaId);
            ViewData["PkarMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", pkArticoli.PkarMgauId);
            ViewData["PkarPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", pkArticoli.PkarPkanId);
            return View(pkArticoli);
        }

        // POST: PkArticolis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkarId,PkarPkanId,PkarMgaaId,PkarQtaPick,PkarQtaSca,PkarMbmgId,PkarMbcsId,PkarMgauId,PkarMgrgId,PkarMgmvProg,PkarCodice,PkarNote,PkarTransferred")] PkArticoli pkArticoli)
        {
            if (id != pkArticoli.PkarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pkArticoli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PkArticoliExists(pkArticoli.PkarId))
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
            ViewData["PkarMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", pkArticoli.PkarMbcsId);
            ViewData["PkarMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", pkArticoli.PkarMbmgId);
            ViewData["PkarMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", pkArticoli.PkarMgaaId);
            ViewData["PkarMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", pkArticoli.PkarMgauId);
            ViewData["PkarPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", pkArticoli.PkarPkanId);
            return View(pkArticoli);
        }

        // GET: PkArticolis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pkArticoli = await _context.PkArticoli
                .Include(p => p.PkarMbcs)
                .Include(p => p.PkarMbmg)
                .Include(p => p.PkarMgaa)
                .Include(p => p.PkarMgau)
                .Include(p => p.PkarPkan)
                .SingleOrDefaultAsync(m => m.PkarId == id);
            if (pkArticoli == null)
            {
                return NotFound();
            }

            return View(pkArticoli);
        }

        // POST: PkArticolis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pkArticoli = await _context.PkArticoli.SingleOrDefaultAsync(m => m.PkarId == id);
            _context.PkArticoli.Remove(pkArticoli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Add(int? id)
        {
            ViewData["PkarMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus");
            ViewData["PkarMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            ViewData["PkarMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr");
            ViewData["PkarPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", id);
            ViewData["PkarMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl");
            return View();
        }


        private bool PkArticoliExists(int id)
        {
            return _context.PkArticoli.Any(e => e.PkarId == id);
        }
    }
}
