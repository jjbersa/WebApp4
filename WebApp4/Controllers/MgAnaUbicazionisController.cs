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
    public class MgAnaUbicazionisController : Controller
    {
        private readonly TestContext _context;

        public MgAnaUbicazionisController(TestContext context)
        {
            _context = context;
        }

        // GET: MgAnaUbicazionis
        public async Task<IActionResult> Index()
        {
            var testContext = _context.MgAnaUbicazioni.Include(m => m.MgauMbmg);
            return View(await testContext.ToListAsync());
        }

        // GET: MgAnaUbicazionis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaUbicazioni = await _context.MgAnaUbicazioni
                .Include(m => m.MgauMbmg)
                .FirstOrDefaultAsync(m => m.MgauId == id);
            if (mgAnaUbicazioni == null)
            {
                return NotFound();
            }

            return View(mgAnaUbicazioni);
        }

        // GET: MgAnaUbicazionis/Create
        public IActionResult Create()
        {
            ViewData["MgauMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            return View();
        }

        // POST: MgAnaUbicazionis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MgauId,MgauMbmgId,MgauCodice,MgauCodCompl,MgauDescr,MgauTreeCtrl,MgauDataIns,MgauLivello,MgauProfondita,MgauLarghezza,MgauAltezza,MgauBloccata,MgauPrenotata,MgauUbiDef")] MgAnaUbicazioni mgAnaUbicazioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mgAnaUbicazioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MgauMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgAnaUbicazioni.MgauMbmgId);
            return View(mgAnaUbicazioni);
        }

        // GET: MgAnaUbicazionis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaUbicazioni = await _context.MgAnaUbicazioni.FirstOrDefaultAsync(m => m.MgauId == id);
            if (mgAnaUbicazioni == null)
            {
                return NotFound();
            }
            ViewData["MgauMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgAnaUbicazioni.MgauMbmgId);
            return View(mgAnaUbicazioni);
        }

        // POST: MgAnaUbicazionis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MgauId,MgauMbmgId,MgauCodice,MgauCodCompl,MgauDescr,MgauTreeCtrl,MgauDataIns,MgauLivello,MgauProfondita,MgauLarghezza,MgauAltezza,MgauBloccata,MgauPrenotata,MgauUbiDef")] MgAnaUbicazioni mgAnaUbicazioni)
        {
            if (id != mgAnaUbicazioni.MgauId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mgAnaUbicazioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MgAnaUbicazioniExists(mgAnaUbicazioni.MgauId))
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
            ViewData["MgauMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgAnaUbicazioni.MgauMbmgId);
            return View(mgAnaUbicazioni);
        }

        // GET: MgAnaUbicazionis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaUbicazioni = await _context.MgAnaUbicazioni
                .Include(m => m.MgauMbmg)
                .FirstOrDefaultAsync(m => m.MgauId == id);
            if (mgAnaUbicazioni == null)
            {
                return NotFound();
            }

            return View(mgAnaUbicazioni);
        }

        // POST: MgAnaUbicazionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mgAnaUbicazioni = await _context.MgAnaUbicazioni.FirstOrDefaultAsync(m => m.MgauId == id);
            _context.MgAnaUbicazioni.Remove(mgAnaUbicazioni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MgAnaUbicazioniExists(int id)
        {
            return _context.MgAnaUbicazioni.Any(e => e.MgauId == id);
        }
    }
}
