using ApplicationHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationHost
{
    public class Seeder
    {
        private readonly ApplicationHostDbContext _context;
        public Seeder(ApplicationHostDbContext context)
        {
            _context = context;
        }

        public Task seeding()
        {
            try
            {
                _context.Database.Migrate();
            }
            catch (Exception)
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
