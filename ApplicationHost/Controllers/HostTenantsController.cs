using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationHost.Models;

namespace ApplicationHost
{
    public class HostTenantsController : Controller
    {
        private readonly ApplicationHostDbContext _context;

        public HostTenantsController(ApplicationHostDbContext context)
        {
            _context = context;
        }

        // GET: HostTenants
        public async Task<IActionResult> Index(string keyword)
        {
            var final = _context.HostTenants.Where(ht => keyword == null ? true : (ht.DbConnectionString.Contains(keyword)
                         || ht.TradingName.Contains(keyword)));

            return View(await final.ToListAsync());
        }

        // GET: HostTenants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostTenant = await _context.HostTenants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostTenant == null)
            {
                return NotFound();
            }

            return View(hostTenant);
        }

        // GET: HostTenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HostTenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TradingName,AuthCode,DbConnectionString")] HostTenant hostTenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hostTenant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostTenant);
        }

        // GET: HostTenants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostTenant = await _context.HostTenants.FindAsync(id);
            if (hostTenant == null)
            {
                return NotFound();
            }
            return View(hostTenant);
        }

        // POST: HostTenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TradingName,AuthCode,DbConnectionString")] HostTenant hostTenant)
        {
            if (id != hostTenant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hostTenant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostTenantExists(hostTenant.Id))
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
            return View(hostTenant);
        }

        // GET: HostTenants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostTenant = await _context.HostTenants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostTenant == null)
            {
                return NotFound();
            }

            return View(hostTenant);
        }

        // POST: HostTenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hostTenant = await _context.HostTenants.FindAsync(id);
            _context.HostTenants.Remove(hostTenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostTenantExists(int id)
        {
            return _context.HostTenants.Any(e => e.Id == id);
        }
    }
}
