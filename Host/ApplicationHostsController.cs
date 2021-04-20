using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Host.Models;

namespace Host
{
    public class ApplicationHostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationHostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationHosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationHosts.ToListAsync());
        }

        // GET: ApplicationHosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationHost = await _context.ApplicationHosts
                .FirstOrDefaultAsync(m => m.HostId == id);
            if (applicationHost == null)
            {
                return NotFound();
            }

            return View(applicationHost);
        }

        // GET: ApplicationHosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationHosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HostId,TradingName,ConnectionString,ApiRoot")] ApplicationHost applicationHost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationHost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationHost);
        }

        // GET: ApplicationHosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationHost = await _context.ApplicationHosts.FindAsync(id);
            if (applicationHost == null)
            {
                return NotFound();
            }
            return View(applicationHost);
        }

        // POST: ApplicationHosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HostId,TradingName,ConnectionString,ApiRoot")] ApplicationHost applicationHost)
        {
            if (id != applicationHost.HostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationHost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationHostExists(applicationHost.HostId))
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
            return View(applicationHost);
        }

        // GET: ApplicationHosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationHost = await _context.ApplicationHosts
                .FirstOrDefaultAsync(m => m.HostId == id);
            if (applicationHost == null)
            {
                return NotFound();
            }

            return View(applicationHost);
        }

        // POST: ApplicationHosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationHost = await _context.ApplicationHosts.FindAsync(id);
            _context.ApplicationHosts.Remove(applicationHost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationHostExists(int id)
        {
            return _context.ApplicationHosts.Any(e => e.HostId == id);
        }
    }
}
