using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce_API_RST_Multi.Data
{
    public class HostDbContext : DbContext
    {
        public HostDbContext()
        {

        }
        public HostDbContext(DbContextOptions<HostDbContext> options) : base(options)
        { 
        
        }

        public DbSet<HostTenant> HostTenants { get; set; }
    }
}
