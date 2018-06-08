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
    public class MbMagsController : Controller
    {
        private readonly TestContext _context;

        public MbMagsController(TestContext context)
        {
            _context = context;
        }

        // GET: MbMags
        public async Task<IActionResult> Index()
        {
            return View(await _context.MbMag.ToListAsync());
        }

        // GET: MbMags/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbMag = await _context.MbMag
                .FirstOrDefaultAsync(m => m.MbmgId == id);
            if (mbMag == null)
            {
                return NotFound();
            }

            return View(mbMag);
        }

        // GET: MbMags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MbMags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MbmgId,MbmgMag,MbmgDescr,MbmgDataFinVal,MbmgCode")] MbMag mbMag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbMag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mbMag);
        }

        // GET: MbMags/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbMag = await _context.MbMag.FirstOrDefaultAsync(m => m.MbmgId == id);
            if (mbMag == null)
            {
                return NotFound();
            }
            return View(mbMag);
        }

        // POST: MbMags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("MbmgId,MbmgMag,MbmgDescr,MbmgDataFinVal,MbmgCode")] MbMag mbMag)
        {
            if (id != mbMag.MbmgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mbMag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MbMagExists(mbMag.MbmgId))
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
            return View(mbMag);
        }

        // GET: MbMags/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mbMag = await _context.MbMag
                .FirstOrDefaultAsync(m => m.MbmgId == id);
            if (mbMag == null)
            {
                return NotFound();
            }

            return View(mbMag);
        }

        // POST: MbMags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var mbMag = await _context.MbMag.FirstOrDefaultAsync(m => m.MbmgId == id);
            _context.MbMag.Remove(mbMag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MbMagExists(short id)
        {
            return _context.MbMag.Any(e => e.MbmgId == id);
        }
    }
}
