using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp4.Models;
using WebApp4.Models.ViewModels;


namespace WebApp4.Controllers
{
    public class WarehouseDetailController : Controller
    {
        private readonly TestContext _context;
        public WarehouseDetailController(TestContext context)
        {
            _context = context;
        }
        // GET: WarehouseDetail


        public async Task<IActionResult> Index()
        {

            var master = (from pkar in _context.PkArticoli
                          join mgaa in _context.MgAnaArt on pkar.PkarMgaaId equals mgaa.MgaaId
                          join pkan in _context.PkAnag on pkar.PkarPkanId equals pkan.PkanId
                          where pkan.PkanScaric == true
                          group pkar by pkar.PkarMgaaId into g

                          select new WarehouseMaster()
                          {
                              whmaMgaaId = g.First().PkarMgaaId,
                              qta = g.Sum(x => Convert.ToInt32(x.PkarQtaSca)),
                              code = g.First().PkarMgaa.MgaaMatricola,
                              component = g.First().PkarMgaa.MgaaDescr
                          }).ToList();

            var results = (from pkar in _context.PkArticoli
                           join mgaa in _context.MgAnaArt on pkar.PkarMgaaId equals mgaa.MgaaId
                           join mbmg in _context.MbMag on pkar.PkarMbmgId equals mbmg.MbmgId
                           join mgau in _context.MgAnaUbicazioni on pkar.PkarMgauId equals mgau.MgauId
                           join pkan in _context.PkAnag on pkar.PkarPkanId equals pkan.PkanId
                           where pkan.PkanScaric == true
                           orderby mgaa.MgaaMatricola
                           select new WarehouseDetail()
                           {
                               qta = Convert.ToInt32(pkar.PkarQtaSca),
                               code = mgaa.MgaaMatricola,
                               component = mgaa.MgaaDescr,
                               pallet = pkan.PkanDesc,
                               warehouse = mbmg.MbmgCode,
                               ubication = mgau.MgauDescr,
                               whdtMgaaId = mgaa.MgaaId,
                               whdtWhmaId = master.First(s => s.whmaMgaaId == mgaa.MgaaId).whmaId

                           }).Include(x => x.whdtMgaa).ToListAsync();
            return View(await results);

        }

    }
}