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
    public class MgMovimentisController : Controller
    {
        private readonly TestContext _context;

        public MgMovimentisController(TestContext context)
        {
            _context = context;
        }

        // GET: MgMovimentis
        public async Task<IActionResult> Index()
        {
            var testContext = _context.MgMovimenti.Include(m => m.MgmvMgaa).Include(m => m.MgmvMgau).Include(m => m.MgmvMgrg).Include(m => m.MgmvPkan).Include(m => m.MgmvPkar).Include(m => m.MgmvUsr);
            return View(await testContext.ToListAsync());
        }

        // GET: MgMovimentis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgMovimenti = await _context.MgMovimenti
                .Include(m => m.MgmvMgaa)
                .Include(m => m.MgmvMgau)
                .Include(m => m.MgmvMgrg)
                .Include(m => m.MgmvPkan)
                .Include(m => m.MgmvPkar)
                .Include(m => m.MgmvUsr)
                .FirstOrDefaultAsync(m => m.MgmvId == id);
            if (mgMovimenti == null)
            {
                return NotFound();
            }

            return View(mgMovimenti);
        }

        // GET: MgMovimentis/Create
        public IActionResult Create()
        {
            ViewData["MgmvMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr");
            ViewData["MgmvMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl");
            ViewData["MgmvMgrgId"] = new SelectList(_context.MgRegistrazioni, "MgrgId", "MgrgId");
            ViewData["MgmvPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc");
            ViewData["MgmvPkarId"] = new SelectList(_context.PkArticoli, "PkarId", "PkarId");
            ViewData["MgmvUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin");
            return View();
        }

        // POST: MgMovimentis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MgmvId,MgmvMgrgId,MgmvProg,MgmvMgaaId,MgmvQuantita,MgmvIdRegDest,MgmvIdRegProv,MgmvCodUbi,MgmvMgauId,MgmvPkanId,MgmvDataIns,MgmvUsrId,MgmvPkarId,MgmvNote")] MgMovimenti mgMovimenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mgMovimenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MgmvMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgMovimenti.MgmvMgaaId);
            ViewData["MgmvMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgMovimenti.MgmvMgauId);
            ViewData["MgmvMgrgId"] = new SelectList(_context.MgRegistrazioni, "MgrgId", "MgrgId", mgMovimenti.MgmvMgrgId);
            ViewData["MgmvPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", mgMovimenti.MgmvPkanId);
            ViewData["MgmvPkarId"] = new SelectList(_context.PkArticoli, "PkarId", "PkarId", mgMovimenti.MgmvPkarId);
            ViewData["MgmvUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgMovimenti.MgmvUsrId);
            return View(mgMovimenti);
        }

        // GET: MgMovimentis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgMovimenti = await _context.MgMovimenti.FirstOrDefaultAsync(m => m.MgmvId == id);
            if (mgMovimenti == null)
            {
                return NotFound();
            }
            ViewData["MgmvMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgMovimenti.MgmvMgaaId);
            ViewData["MgmvMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgMovimenti.MgmvMgauId);
            ViewData["MgmvMgrgId"] = new SelectList(_context.MgRegistrazioni, "MgrgId", "MgrgId", mgMovimenti.MgmvMgrgId);
            ViewData["MgmvPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", mgMovimenti.MgmvPkanId);
            ViewData["MgmvPkarId"] = new SelectList(_context.PkArticoli, "PkarId", "PkarId", mgMovimenti.MgmvPkarId);
            ViewData["MgmvUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgMovimenti.MgmvUsrId);
            return View(mgMovimenti);
        }

        // POST: MgMovimentis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MgmvId,MgmvMgrgId,MgmvProg,MgmvMgaaId,MgmvQuantita,MgmvIdRegDest,MgmvIdRegProv,MgmvCodUbi,MgmvMgauId,MgmvPkanId,MgmvDataIns,MgmvUsrId,MgmvPkarId,MgmvNote")] MgMovimenti mgMovimenti)
        {
            if (id != mgMovimenti.MgmvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mgMovimenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MgMovimentiExists(mgMovimenti.MgmvId))
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
            ViewData["MgmvMgaaId"] = new SelectList(_context.MgAnaArt, "MgaaId", "MgaaDescr", mgMovimenti.MgmvMgaaId);
            ViewData["MgmvMgauId"] = new SelectList(_context.MgAnaUbicazioni, "MgauId", "MgauCodCompl", mgMovimenti.MgmvMgauId);
            ViewData["MgmvMgrgId"] = new SelectList(_context.MgRegistrazioni, "MgrgId", "MgrgId", mgMovimenti.MgmvMgrgId);
            ViewData["MgmvPkanId"] = new SelectList(_context.PkAnag, "PkanId", "PkanDesc", mgMovimenti.MgmvPkanId);
            ViewData["MgmvPkarId"] = new SelectList(_context.PkArticoli, "PkarId", "PkarId", mgMovimenti.MgmvPkarId);
            ViewData["MgmvUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgMovimenti.MgmvUsrId);
            return View(mgMovimenti);
        }

        // GET: MgMovimentis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgMovimenti = await _context.MgMovimenti
                .Include(m => m.MgmvMgaa)
                .Include(m => m.MgmvMgau)
                .Include(m => m.MgmvMgrg)
                .Include(m => m.MgmvPkan)
                .Include(m => m.MgmvPkar)
                .Include(m => m.MgmvUsr)
                .FirstOrDefaultAsync(m => m.MgmvId == id);
            if (mgMovimenti == null)
            {
                return NotFound();
            }

            return View(mgMovimenti);
        }

        // POST: MgMovimentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mgMovimenti = await _context.MgMovimenti.FirstOrDefaultAsync(m => m.MgmvId == id);
            _context.MgMovimenti.Remove(mgMovimenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MgMovimentiExists(int id)
        {
            return _context.MgMovimenti.Any(e => e.MgmvId == id);
        }
    }
}
