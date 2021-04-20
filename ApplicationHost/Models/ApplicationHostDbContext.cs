using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationHost.Models
{
    public class ApplicationHostDbContext : DbContext
    {
        public ApplicationHostDbContext()
        {

        }
        public ApplicationHostDbContext(DbContextOptions<ApplicationHostDbContext> options) : base(options)
        { 
        
        }

        public DbSet<HostTenant> HostTenants { get; set; }
    }
}
