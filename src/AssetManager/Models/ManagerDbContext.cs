using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AssetManager.Entity;

namespace AssetManager.Models
{
    public class ManagerDbContext: DbContext
    {
        public ManagerDbContext(DbContextOptions options):base(options)       {       }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>(unit =>
            {
                unit.Property(e => e.UNIT_CODE).IsRequired();

            });
        }

        public virtual DbSet<Unit> Unit { get; set; }
    }
}
