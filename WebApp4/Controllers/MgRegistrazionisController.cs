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
    public class MgRegistrazionisController : Controller
    {
        private readonly TestContext _context;

        public MgRegistrazionisController(TestContext context)
        {
            _context = context;
        }

        // GET: MgRegistrazionis
        public async Task<IActionResult> Index()
        {
            var testContext = _context.MgRegistrazioni.Include(m => m.MgrgCreationUserUsr).Include(m => m.MgrgLastEditUserUsr).Include(m => m.MgrgMbcs).Include(m => m.MgrgMbmg);
            return View(await testContext.ToListAsync());
        }

        // GET: MgRegistrazionis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgRegistrazioni = await _context.MgRegistrazioni
                .Include(m => m.MgrgCreationUserUsr)
                .Include(m => m.MgrgLastEditUserUsr)
                .Include(m => m.MgrgMbcs)
                .Include(m => m.MgrgMbmg)
                .FirstOrDefaultAsync(m => m.MgrgId == id);
            if (mgRegistrazioni == null)
            {
                return NotFound();
            }

            return View(mgRegistrazioni);
        }

        // GET: MgRegistrazionis/Create
        public IActionResult Create()
        {
            ViewData["MgrgCreationUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin");
            ViewData["MgrgLastEditUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin");
            ViewData["MgrgMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus");
            ViewData["MgrgMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode");
            return View();
        }

        // POST: MgRegistrazionis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MgrgId,MgrgMbmgId,MgrgMbcsId,MgrgData,MgrgNum,MgrgDocRif,MgrgDataRif,MgrgCreationDate,MgrgCreationUserUsrId,MgrgLastEditDate,MgrgLastEditUserUsrId")] MgRegistrazioni mgRegistrazioni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mgRegistrazioni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MgrgCreationUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgCreationUserUsrId);
            ViewData["MgrgLastEditUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgLastEditUserUsrId);
            ViewData["MgrgMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", mgRegistrazioni.MgrgMbcsId);
            ViewData["MgrgMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgRegistrazioni.MgrgMbmgId);
            return View(mgRegistrazioni);
        }

        // GET: MgRegistrazionis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgRegistrazioni = await _context.MgRegistrazioni.FirstOrDefaultAsync(m => m.MgrgId == id);
            if (mgRegistrazioni == null)
            {
                return NotFound();
            }
            ViewData["MgrgCreationUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgCreationUserUsrId);
            ViewData["MgrgLastEditUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgLastEditUserUsrId);
            ViewData["MgrgMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", mgRegistrazioni.MgrgMbcsId);
            ViewData["MgrgMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgRegistrazioni.MgrgMbmgId);
            return View(mgRegistrazioni);
        }

        // POST: MgRegistrazionis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MgrgId,MgrgMbmgId,MgrgMbcsId,MgrgData,MgrgNum,MgrgDocRif,MgrgDataRif,MgrgCreationDate,MgrgCreationUserUsrId,MgrgLastEditDate,MgrgLastEditUserUsrId")] MgRegistrazioni mgRegistrazioni)
        {
            if (id != mgRegistrazioni.MgrgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mgRegistrazioni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MgRegistrazioniExists(mgRegistrazioni.MgrgId))
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
            ViewData["MgrgCreationUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgCreationUserUsrId);
            ViewData["MgrgLastEditUserUsrId"] = new SelectList(_context.SecUsers, "UsrId", "UsrLogin", mgRegistrazioni.MgrgLastEditUserUsrId);
            ViewData["MgrgMbcsId"] = new SelectList(_context.MbCausal, "MbcsId", "MbcsCaus", mgRegistrazioni.MgrgMbcsId);
            ViewData["MgrgMbmgId"] = new SelectList(_context.MbMag, "MbmgId", "MbmgCode", mgRegistrazioni.MgrgMbmgId);
            return View(mgRegistrazioni);
        }

        // GET: MgRegistrazionis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgRegistrazioni = await _context.MgRegistrazioni
                .Include(m => m.MgrgCreationUserUsr)
                .Include(m => m.MgrgLastEditUserUsr)
                .Include(m => m.MgrgMbcs)
                .Include(m => m.MgrgMbmg)
                .FirstOrDefaultAsync(m => m.MgrgId == id);
            if (mgRegistrazioni == null)
            {
                return NotFound();
            }

            return View(mgRegistrazioni);
        }

        // POST: MgRegistrazionis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mgRegistrazioni = await _context.MgRegistrazioni.FirstOrDefaultAsync(m => m.MgrgId == id);
            _context.MgRegistrazioni.Remove(mgRegistrazioni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MgRegistrazioniExists(int id)
        {
            return _context.MgRegistrazioni.Any(e => e.MgrgId == id);
        }
    }
}
