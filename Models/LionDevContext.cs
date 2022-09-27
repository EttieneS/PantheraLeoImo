using Microsoft.EntityFrameworkCore;
using System;

namespace LionDevAPI.Models
{
    public class LionDevContext: DbContext
    {
        public LionDevContext(DbContextOptions<LionDevContext> options)
            : base(options) { }

        public DbSet<Leave> Leaves { get; set; }
    }
}
