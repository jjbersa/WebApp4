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
    public class MgAnaArtsController : Controller
    {
        private readonly TestContext _context;

        public MgAnaArtsController(TestContext context)
        {
            _context = context;
        }

        // GET: MgAnaArts
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var components = from s in _context.MgAnaArt
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                components = components.Where(s => s.MgaaDescr.Contains(searchString)
                                       || s.MgaaMatricola.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    components = components.OrderByDescending(s => s.MgaaDescr);
                    break;
                case "Date":
                    components = components.OrderBy(s => s.MgaaDataIns);
                    break;
                case "date_desc":
                    components = components.OrderByDescending(s => s.MgaaDataIns);
                    break;
                default:
                    components = components.OrderBy(s => s.MgaaMatricola);
                    break;
            }
            int pageSize = 7;
            return View(await PaginatedList<MgAnaArt>.CreateAsync(components.AsNoTracking(), page ?? 1, pageSize));

            //return View(await _context.MgAnaArt.ToListAsync());
        }

        // GET: MgAnaArts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaArt = await _context.MgAnaArt
                .FirstOrDefaultAsync(m => m.MgaaId == id);
            if (mgAnaArt == null)
            {
                return NotFound();
            }

            return View(mgAnaArt);
        }

        // GET: MgAnaArts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MgAnaArts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MgaaId,MgaaMbdcClasse,MgaaMatricola,MgaaDescr,MgaaNote,MgaaDataIns,MgaaDataUltMod")] MgAnaArt mgAnaArt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emptyComponent = new MgAnaArt();

                    _context.Add(mgAnaArt);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (DbUpdateException  ex )
            {
                string msg = "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.";
                if (ex.InnerException.Message.Contains("UNIQUE"))
                    msg = "Attribute Code must be unique";
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", msg);
            }
            return View(mgAnaArt);
        }

        //// GET: MgAnaArts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var mgAnaArt = await _context.MgAnaArt.FirstOrDefaultAsync(m => m.MgaaId == id);
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(mgAnaArt);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateException /* ex */)
        //        {
        //            //Log the error (uncomment ex variable name and write a log.)
        //            ModelState.AddModelError("", "Unable to save changes. " +
        //                "Try again, and if the problem persists, " +
        //                "see your system administrator.");
        //        }
        //    }
        //    return View(mgAnaArt);
        //    //var mgAnaArt = await _context.MgAnaArt.FirstOrDefaultAsync(m => m.MgaaId == id);
        //    //if (mgAnaArt == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return View(mgAnaArt);
        //}

        //// POST: MgAnaArts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("MgaaId,MgaaMbdcClasse,MgaaMatricola,MgaaDescr,MgaaNote,MgaaDataIns,MgaaDataUltMod")] MgAnaArt mgAnaArt)
        //{
        //    if (id != mgAnaArt.MgaaId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(mgAnaArt);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MgAnaArtExists(mgAnaArt.MgaaId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(mgAnaArt);
        //}
        // GET: MgAnaArts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaArt = await _context.MgAnaArt.FirstOrDefaultAsync(m => m.MgaaId == id);
            if (mgAnaArt == null)
            {
                return NotFound();
            }
            return View(mgAnaArt);
        }

        // POST: MgAnaArts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MgaaId,MgaaMbdcClasse,MgaaMatricola,MgaaDescr,MgaaNote,MgaaDataIns,MgaaDataUltMod")] MgAnaArt mgAnaArt)
        {
            if (id != mgAnaArt.MgaaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mgAnaArt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MgAnaArtExists(mgAnaArt.MgaaId))
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
            return View(mgAnaArt);
        }

        // GET: MgAnaArts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mgAnaArt = await _context.MgAnaArt
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.MgaaId == id);
            if (mgAnaArt == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(mgAnaArt);
        }

        // POST: MgAnaArts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mgAnaArt = await _context.MgAnaArt.AsNoTracking().FirstOrDefaultAsync(m => m.MgaaId == id);
            if (mgAnaArt == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.MgAnaArt.Remove(mgAnaArt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool MgAnaArtExists(int id)
        {
            return _context.MgAnaArt.Any(e => e.MgaaId == id);
        }
    }
}
