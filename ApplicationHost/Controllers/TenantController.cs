using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationHost.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationHost.Controllers
{
    [Route("api/tenant")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ApplicationHostDbContext _context;
        public TenantController(ApplicationHostDbContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> getConnectionStringById(int id)
        {
            var result = await _context.HostTenants.Where(h=>h.Id == id)
                                .FirstOrDefaultAsync();
            if (result != null)
            {
                return Ok(result.DbConnectionString);
            }
            return NotFound();
        }
    }
}
