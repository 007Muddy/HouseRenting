using HouseRenting.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using HouseRenting.Models;

namespace HouseRenting.Data
{
    public class HouseDbContext : IdentityDbContext<HouseRentingUser>
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
        : base(options)
        {
        }
        public DbSet<House> House { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        
    }

}
