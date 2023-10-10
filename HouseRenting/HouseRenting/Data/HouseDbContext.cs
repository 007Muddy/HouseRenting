using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HouseRenting.Data
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<HouseRenting.Models.House> House { get; set; } = default!;
    }

}
