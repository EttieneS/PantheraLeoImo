using Microsoft.EntityFrameworkCore;
using System;

namespace LionDevAPI.Models
{
    public class LionDevContext: DbContext
    {
        public LionDevContext(DbContextOptions<LionDevContext> options)
            : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
